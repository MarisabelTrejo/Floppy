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


        // Positon of rectangles
        // I want a set position for the rectangles, do I want two rectangles Bottom and Top?
       // for (int i = 0; i < CountOfEachShape; i++) {
           // Random newRandom = new Random();
           // int RandomHeight = newRandom.Next();
           // var TopRectangle = new GameRectangle(ScreenWidth ,0 , 100, 200,  Color.GREEN);
           // var BottomRectangle = new GameRectangle(ScreenWidth ,ScreenHeight - 200, 100, 200,  Color.GREEN);

           // TopRectangle.Velocity = new Vector2(-1, 0);
           // BottomRectangle.Velocity = new Vector2(-1, 0);

         //   Objects.Add(TopRectangle);
       //     Objects.Add(BottomRectangle);
       // }

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
                int RandomHeight = newRandom.Next(300,ScreenHeight);
                var TopRectangle = new GameRectangle(ScreenWidth ,0 , 100, 200,  Color.GREEN);
                var BottomRectangle = new GameRectangle(ScreenWidth ,ScreenHeight - 200, 100, RandomHeight,  Color.GREEN);
                // generate a rectangle that is screenheight/2 

                TopRectangle.Velocity = new Vector2(-2, 0);
                BottomRectangle.Velocity = new Vector2(-2, 0);

                Objects.Add(TopRectangle);
                Objects.Add(BottomRectangle);
                count = 0;
            }

            // Check if link is on any of the shapes
            foreach (var obj in Objects) {
                if (obj is Shape) {
                    var shape = (Shape)obj;
                    if (Raylib.CheckCollisionRecs(Player.Rect(), shape.Rect())) {
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



        //Raylib.CloseWindow();
    }

    private Vector2 RandomPosition(int screenHeight, int screenWidth)
    {
        throw new NotImplementedException();
    }
}