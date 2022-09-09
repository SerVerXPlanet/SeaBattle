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
        StringBuilder msg = new StringBuilder();
        Field fieldNPC;
        Field fieldHuman;


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
        }


        public void AddText(string text)
        {
            msg.Insert(0, text + Environment.NewLine);

            TextChanged?.Invoke();
        }


        internal void NewGame()
        {
            State = GameStatus.Settings;
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
            Random rnd = new Random();
            //Thread.Sleep();
            await Delay(rnd.Next(500, 1500));

            bool isLegal = false;
            Status status;
            bool isHit = false;
            int x, y;

            do
            {
                x = rnd.Next(1, fieldHuman.HorizontalSize + 1);
                y = rnd.Next(1, fieldHuman.VerticalSize + 1);

                status = fieldHuman.Cells[x, y];
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

            fieldHuman.Mode = Mode.Check;
            isLegal = fieldHuman.ActivateCell(new Point(x, y), MouseButtons.None);
            fieldHuman.Mode = Mode.View;
            
            AddText($"@   {fieldHuman.NamesX[x - 1]}{fieldHuman.NamesY[y - 1].Trim()}   {(isHit ? "X" : "")}");
            
            if (fieldHuman.NavyCheck())
            {
                AddText("Компьютер выиграл!");
                Stop();
                return;
            }
            
            if (isHit)
                DoStepNPC();
            else
                fieldNPC.Mode = Mode.Battle;
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

            AddText($"/\\   {fieldNPC.NamesX[currentCell.X - 1]}{fieldNPC.NamesY[currentCell.Y - 1].Trim()}   {(isHit ? "X" : "")}");

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
