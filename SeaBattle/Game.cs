using System;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SeaFight;


namespace SeaBattle
{
    public enum GameStatus { Closed, Open, Settings };



    class Game
    {
        static readonly Point emptyPoint = new Point(0, 0);

        StringBuilder msg = new StringBuilder();
        readonly Field fieldNPC;
        readonly Field fieldHuman;

        Point lastDamaged = emptyPoint; // флаг попадания
        Point prevPoint;
        bool? orient; // ориентация поврежденного корабля


        public GameStatus State { get; set; }
        public bool YourStep { get; set; }
        public String Msg { get => msg.ToString(); }


        public delegate void Changed();
        public event Changed TextChanged;


        public Game(Field fieldNPC, Field fieldHuman)
        {
            State = GameStatus.Closed;
            msg = new StringBuilder();
            this.fieldNPC = fieldNPC;
            this.fieldHuman = fieldHuman;

            AddText("Выберите режим игры");
        }


        public void Clear()
        {
            msg.Clear();

            fieldNPC.ClearState();
            fieldHuman.ClearState();

            fieldNPC.Invalidate();
            fieldHuman.Invalidate();

            lastDamaged = emptyPoint;
            orient = null;
            prevPoint = emptyPoint;
        }


        public void AddText(string text)
        {
            msg.Insert(0, text + Environment.NewLine);

            TextChanged?.Invoke();
        }


        internal void NewGame()
        {
            State = GameStatus.Settings;

            AddText("Расставьте свои корабли");

            fieldHuman.Mode = Mode.Build;
            fieldHuman.SetLights(Step.Prepare);
        }


        internal void Start()
        {
            State = GameStatus.Open;
        }


        internal void Stop()
        {
            State = GameStatus.Closed;

            fieldNPC.Mode = Mode.View;
            fieldHuman.Mode = Mode.View;

            fieldHuman.SetLights(Step.Stop);
            fieldNPC.SetLights(Step.Stop);

            AddText("Игра окончена");
        }

        internal bool First()
        {
            Random rnd = new Random();
            bool youFirst = Convert.ToBoolean(rnd.Next(0, 2));
            AddText($"Первый ход за {(youFirst ? "Вами" : "компьютером")}");
            return youFirst;
        }

        async internal void DoStepNPC()
        {
            fieldHuman.SetLights(Step.Run);
            fieldNPC.SetLights(Step.Wait);

            Random rnd = new Random();
            //Thread.Sleep();
            await Delay(rnd.Next(500, 1500));

            bool isHit = false; // флаг попадания

            Status status;
            int x = 0, y = 0;

            do
            {
                if (lastDamaged.X == 0)
                {
                    x = rnd.Next(1, fieldHuman.HorizontalSize + 1);
                    y = rnd.Next(1, fieldHuman.VerticalSize + 1);
                }
                else
                {
                    int sign = rnd.Next(0, 2);

                    if(orient is null && sign == 0 || !(orient is null) && (bool)orient)
                    {
                        x = GetNearValue(prevPoint.X, fieldHuman.HorizontalSize);
                        y = prevPoint.Y;
                    }
                    else if (orient is null && sign == 1 || !(orient is null) && !(bool)orient)
                    {
                        x = prevPoint.X;
                        y = GetNearValue(prevPoint.Y, fieldHuman.VerticalSize);
                    }
                }

                status = fieldHuman.Cells[x, y];

                if (!(orient is null) && status == Status.Hit)
                {
                    prevPoint = new Point(x, y);
                }
            }
            while (!(status == Status.Ship || status == Status.Empty));

            switch (status)
            {
                case Status.Ship:
                    isHit = true;
                    break;
                case Status.Empty:
                    isHit = false;
                    break;
            }

            Point currentCell = new Point(x, y);

            if(isHit)
                lastDamaged = currentCell;

            fieldHuman.Mode = Mode.Check;
            _ = fieldHuman.ActivateCell(currentCell, MouseButtons.None);
            fieldHuman.Mode = Mode.View;

            bool isShipDestroyed = false;

            if (isHit)
            {
                isShipDestroyed = fieldHuman.IsShipDestroyed(currentCell, true);
            }

            char flag = isHit ? (isShipDestroyed ? '#' : 'X') : ' ';
            
            AddText($"@   {fieldHuman.NamesX[x - 1]}{fieldHuman.NamesY[y - 1].Trim()}   {flag}");
            
            if (fieldHuman.NavyCheck())
            {
                AddText("Компьютер выиграл!");
                Stop();
                return;
            }

            if (isHit)
            {
                if (orient is null && fieldHuman.Cells[prevPoint.X, prevPoint.Y] == Status.Hit)
                {
                    if (prevPoint.X == x)
                        orient = false;
                    else if (prevPoint.Y == y)
                        orient = true;
                }

                prevPoint = currentCell;

                if (isShipDestroyed)
                {
                    lastDamaged = emptyPoint;
                    orient = null;
                    prevPoint = emptyPoint;
                }

                DoStepNPC();
            }
            else
            {
                fieldNPC.Mode = Mode.Battle;
                fieldHuman.SetLights(Step.Wait);
                fieldNPC.SetLights(Step.Run);
            }
        }


        int GetNearValue(int oldVal, int maxVal)
        {
            int newVal;
            
            if (oldVal == 1)
                newVal = oldVal + 1;
            else if (oldVal == maxVal)
                newVal = oldVal - 1;
            else
            {
                Random rnd = new Random();
                int sign = rnd.Next(0, 2) == 0 ? -1 : 1;
                newVal = oldVal + sign;
            }

            return newVal;
        }


        internal void DoStepHuman()
        {
            if (fieldNPC.Mode == Mode.View)
                return;

            Point currentCell = fieldNPC.ActiveCell;

            bool isHit = false;

            switch (fieldNPC.Enemies[currentCell.X, currentCell.Y])
            {
                case Status.Ship:
                    isHit = true;
                    break;
                case Status.Empty:
                    isHit = false;
                    break;
            }

            bool isShipDestroyed = false;

            if (isHit)
            {
                isShipDestroyed = fieldNPC.IsShipDestroyed(currentCell);
            }

            char flag = isHit ? (isShipDestroyed ? '#' : 'X') : ' ';

            AddText($"/\\   {fieldNPC.NamesX[currentCell.X - 1]}{fieldNPC.NamesY[currentCell.Y - 1].Trim()}   {flag}");

            if (!isHit)
            {
                fieldNPC.Mode = Mode.View;
                DoStepNPC();
            }

            if (fieldNPC.DestructionCheck())
            {
                AddText("Вы выиграли!");
                Stop();
                return;
            }
        }


        internal void GenerateNPC()
        {
            bool sucsess = fieldNPC.GenerateShips();

            string s = fieldNPC.ToString();

            if (!sucsess)
            {
                fieldNPC.Mode = Mode.View;
                AddText("Не удалось расставить корабли! Уменьшите их количество и/или размеры.");
            }

            AddText("Корабли противника установлены!");
        }


        public async Task Delay(int ms)
        {
            await Task.Delay(ms);
        }


    }
}
