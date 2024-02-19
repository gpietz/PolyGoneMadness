
using OpenTK.Graphics.ES20;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace PolyGoneMadness;

public interface IGameWindow
{

}

public sealed class Game : GameWindow, IGameWindow
{
    private int _screenWidth;
    private int _screenHeight;
    
    public Game(int width, int height, string title) :base(GameWindowSettings.Default, NativeWindowSettings.Default)
    {
        _screenWidth = width;
        _screenHeight = height;

        CenterWindow(new Vector2i(_screenWidth, _screenHeight));
    }

    protected override void OnResize(ResizeEventArgs e)
    {
        base.OnResize(e);
        GL.Viewport(0, 0, e.Width, e.Height);
        _screenWidth = e.Width;
        _screenHeight = e.Height;
    }

    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        base.OnUpdateFrame(args);

        if (KeyboardState.IsKeyDown(Keys.Escape))
        {
            Close();
        }
    }
    
    protected override void OnRenderFrame(FrameEventArgs args)
    {
        GL.ClearColor(0.1f, 0.1f, 0.25f, 1f);
        GL.Clear(ClearBufferMask.ColorBufferBit);
        Context.SwapBuffers();
        base.OnRenderFrame(args);
    }
}
