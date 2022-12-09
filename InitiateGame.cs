using Raylib_cs;
using System.Numerics;

class Floppy {

    Random Rdm = new Random();


    public void Play() {
        var ScreenHeight = 720; // 720
        var ScreenWidth = 1280; //450


        Raylib.InitWindow(ScreenWidth, ScreenHeight, "Floppy");
        Raylib.SetTargetFPS(60);

        var Player = new Player();
        var Title = new GameText("Score:", Color.WHITE);
        var Objects = new List<GameObject>();


        
        // Player position
        Player.Position = new Vector2(200, 200);
        Title.Position = new Vector2(20);

        Objects.Add(Player);
        Objects.Add(Title);

        int count = 0;

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLUE);

            // Draw all of the objects in their current location
            foreach (var obj in Objects) {
                obj.Draw();
            }

            //
            if (count == 150){
                
                Random newRandom = new Random();
                int Gap = 150;

                int RandomHeight = newRandom.Next(ScreenHeight/2);
                var TopRectangle = new GameRectangle(ScreenWidth ,0 , 100, RandomHeight,  Color.GREEN);
                int BottomHeight = ScreenHeight - (Gap + RandomHeight);
                var BottomRectangle = new GameRectangle(ScreenWidth , Gap + RandomHeight, 100, BottomHeight,  Color.GREEN);
                

                // generate a rectangle that is screenheight/2 

                TopRectangle.Velocity = new Vector2(-2, 0);
                BottomRectangle.Velocity = new Vector2(-2, 0);

                Objects.Add(TopRectangle);
                Objects.Add(BottomRectangle);
                count = 0;
            }

            // Check if link is on any of the shapes
            foreach (var obj in Objects) {
                if (obj is GameRectangle) {
                    var shape = (GameRectangle)obj;
                    if (Raylib.CheckCollisionRecs(Player.Rect(), shape.Rect())) {
                        Console.WriteLine("MEOW");
                        Raylib.CloseWindow();
                    }
                }
            }

            Raylib.EndDrawing();

            // Move all of the objects to their next location
            foreach (var obj in Objects) {
                obj.Move();
            }
            count ++;
        }
    }

}