using Raylib_cs;
using System.Numerics;
class Player: GameObject {

    Texture2D texture;

    public Player() {
        
        var image = Raylib.LoadImage("Mosley.png");
        Raylib.ImageResize(ref image, 70, 70); 
        this.texture = Raylib.LoadTextureFromImage(image);
        Raylib.UnloadImage(image);
    }

    public Rectangle Rect() {
        return new Rectangle(Position.X, Position.Y, 70, 70);
    }

    public override void Move()
    {
        // Reset the velocity every frame unless keys are being pressed
        var velocity = new Vector2(0, 3);
        var movementSpeed = 3;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE)) {
            velocity.Y = -movementSpeed;
        }

        Velocity = velocity;

        base.Move();
    }

    public override void Draw() {
        Raylib.DrawTexture(this.texture, (int)Position.X, (int)Position.Y, Color.WHITE);
    }
}