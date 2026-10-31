using Lua;
using Raylib_cs;

namespace vubox.modding;


[LuaObject]
public partial class ModAPI_Input
{
    [LuaMember("a")]
    public readonly int A = (int)KeyboardKey.A;

    [LuaMember("b")]
    public readonly int B = (int)KeyboardKey.B;

    [LuaMember("c")]
    public readonly int C = (int)KeyboardKey.C;

    [LuaMember("d")]
    public readonly int D = (int)KeyboardKey.D;

    [LuaMember("e")]
    public readonly int E = (int)KeyboardKey.E;

    [LuaMember("f")]
    public readonly int F = (int)KeyboardKey.F;

    [LuaMember("g")]
    public readonly int G = (int)KeyboardKey.G;

    [LuaMember("h")]
    public readonly int H = (int)KeyboardKey.H;

    [LuaMember("i")]
    public readonly int I = (int)KeyboardKey.I;

    [LuaMember("j")]
    public readonly int J = (int)KeyboardKey.J;

    [LuaMember("k")]
    public readonly int K = (int)KeyboardKey.K;

    [LuaMember("l")]
    public readonly int L = (int)KeyboardKey.L;

    [LuaMember("m")]
    public readonly int M = (int)KeyboardKey.M;

    [LuaMember("n")]
    public readonly int N = (int)KeyboardKey.N;

    [LuaMember("o")]
    public readonly int O = (int)KeyboardKey.O;

    [LuaMember("p")]
    public readonly int P = (int)KeyboardKey.P;

    [LuaMember("q")]
    public readonly int Q = (int)KeyboardKey.Q;

    [LuaMember("r")]
    public readonly int R = (int)KeyboardKey.R;

    [LuaMember("s")]
    public readonly int S = (int)KeyboardKey.S;

    [LuaMember("t")]
    public readonly int T = (int)KeyboardKey.T;

    [LuaMember("u")]
    public readonly int U = (int)KeyboardKey.U;

    [LuaMember("v")]
    public readonly int V = (int)KeyboardKey.V;

    [LuaMember("w")]
    public readonly int W = (int)KeyboardKey.W;

    [LuaMember("x")]
    public readonly int X = (int)KeyboardKey.X;

    [LuaMember("y")]
    public readonly int Y = (int)KeyboardKey.Y;

    [LuaMember("z")]
    public readonly int Z = (int)KeyboardKey.Z;

    // Number row
    [LuaMember("zero")]
    public readonly int Zero = (int)KeyboardKey.Zero;

    [LuaMember("one")]
    public readonly int One = (int)KeyboardKey.One;

    [LuaMember("two")]
    public readonly int Two = (int)KeyboardKey.Two;

    [LuaMember("three")]
    public readonly int Three = (int)KeyboardKey.Three;

    [LuaMember("four")]
    public readonly int Four = (int)KeyboardKey.Four;

    [LuaMember("five")]
    public readonly int Five = (int)KeyboardKey.Five;

    [LuaMember("six")]
    public readonly int Six = (int)KeyboardKey.Six;

    [LuaMember("seven")]
    public readonly int Seven = (int)KeyboardKey.Seven;

    [LuaMember("eight")]
    public readonly int Eight = (int)KeyboardKey.Eight;

    [LuaMember("nine")]
    public readonly int Nine = (int)KeyboardKey.Nine;

    // special row
    [LuaMember("lctrl")]
    public readonly int LControl = (int)KeyboardKey.LeftControl;
    [LuaMember("lalt")]
    public readonly int LAlt = (int)KeyboardKey.LeftAlt;
    [LuaMember("lshift")]
    public readonly int LShift = (int)KeyboardKey.LeftShift;
    [LuaMember("rctrl")]
    public readonly int RControl = (int)KeyboardKey.RightControl;
    [LuaMember("ralt")]
    public readonly int RAlt = (int)KeyboardKey.RightAlt;
    [LuaMember("rshift")]
    public readonly int RShift = (int)KeyboardKey.RightShift;
    [LuaMember("esc")]
    public readonly int Esc = (int)KeyboardKey.Escape;
    [LuaMember("lsuper")]
    public readonly int LSuper = (int)KeyboardKey.LeftSuper;
    [LuaMember("rsuper")]
    public readonly int RSuper = (int)KeyboardKey.RightSuper;
        // whitespace / editing
    [LuaMember("space")]
    public readonly int Space = (int)KeyboardKey.Space;
    [LuaMember("enter")]
    public readonly int Enter = (int)KeyboardKey.Enter;
    [LuaMember("tab")]
    public readonly int Tab = (int)KeyboardKey.Tab;
    [LuaMember("backspace")]
    public readonly int Backspace = (int)KeyboardKey.Backspace;
    [LuaMember("insert")]
    public readonly int Insert = (int)KeyboardKey.Insert;
    [LuaMember("delete")]
    public readonly int Delete = (int)KeyboardKey.Delete;

    // arrows
    [LuaMember("up")]
    public readonly int Up = (int)KeyboardKey.Up;
    [LuaMember("down")]
    public readonly int Down = (int)KeyboardKey.Down;
    [LuaMember("left")]
    public readonly int Left = (int)KeyboardKey.Left;
    [LuaMember("right")]
    public readonly int Right = (int)KeyboardKey.Right;

    // navigation
    [LuaMember("home")]
    public readonly int Home = (int)KeyboardKey.Home;
    [LuaMember("end")]
    public readonly int End = (int)KeyboardKey.End;
    [LuaMember("pageup")]
    public readonly int PageUp = (int)KeyboardKey.PageUp;
    [LuaMember("pagedown")]
    public readonly int PageDown = (int)KeyboardKey.PageDown;

    // locks / system
    [LuaMember("capslock")]
    public readonly int CapsLock = (int)KeyboardKey.CapsLock;
    [LuaMember("scrolllock")]
    public readonly int ScrollLock = (int)KeyboardKey.ScrollLock;
    [LuaMember("numlock")]
    public readonly int NumLock = (int)KeyboardKey.NumLock;
    [LuaMember("printscreen")]
    public readonly int PrintScreen = (int)KeyboardKey.PrintScreen;
    [LuaMember("pause")]
    public readonly int Pause = (int)KeyboardKey.Pause;
    [LuaMember("menu")]
    public readonly int KeyboardMenu = (int)KeyboardKey.KeyboardMenu;

    // punctuation
    [LuaMember("apostrophe")]
    public readonly int Apostrophe = (int)KeyboardKey.Apostrophe;
    [LuaMember("comma")]
    public readonly int Comma = (int)KeyboardKey.Comma;
    [LuaMember("minus")]
    public readonly int Minus = (int)KeyboardKey.Minus;
    [LuaMember("period")]
    public readonly int Period = (int)KeyboardKey.Period;
    [LuaMember("slash")]
    public readonly int Slash = (int)KeyboardKey.Slash;
    [LuaMember("semicolon")]
    public readonly int Semicolon = (int)KeyboardKey.Semicolon;
    [LuaMember("equal")]
    public readonly int Equal = (int)KeyboardKey.Equal;
    [LuaMember("lbracket")]
    public readonly int LeftBracket = (int)KeyboardKey.LeftBracket;
    [LuaMember("backslash")]
    public readonly int Backslash = (int)KeyboardKey.Backslash;
    [LuaMember("rbracket")]
    public readonly int RightBracket = (int)KeyboardKey.RightBracket;
    [LuaMember("grave")]
    public readonly int Grave = (int)KeyboardKey.Grave;

    // function keys
    [LuaMember("f1")]
    public readonly int F1 = (int)KeyboardKey.F1;
    [LuaMember("f2")]
    public readonly int F2 = (int)KeyboardKey.F2;
    [LuaMember("f3")]
    public readonly int F3 = (int)KeyboardKey.F3;
    [LuaMember("f4")]
    public readonly int F4 = (int)KeyboardKey.F4;
    [LuaMember("f5")]
    public readonly int F5 = (int)KeyboardKey.F5;
    [LuaMember("f6")]
    public readonly int F6 = (int)KeyboardKey.F6;
    [LuaMember("f7")]
    public readonly int F7 = (int)KeyboardKey.F7;
    [LuaMember("f8")]
    public readonly int F8 = (int)KeyboardKey.F8;
    [LuaMember("f9")]
    public readonly int F9 = (int)KeyboardKey.F9;
    [LuaMember("f10")]
    public readonly int F10 = (int)KeyboardKey.F10;
    [LuaMember("f11")]
    public readonly int F11 = (int)KeyboardKey.F11;
    [LuaMember("f12")]
    public readonly int F12 = (int)KeyboardKey.F12;

    // keypad
    [LuaMember("kp0")]
    public readonly int Kp0 = (int)KeyboardKey.Kp0;
    [LuaMember("kp1")]
    public readonly int Kp1 = (int)KeyboardKey.Kp1;
    [LuaMember("kp2")]
    public readonly int Kp2 = (int)KeyboardKey.Kp2;
    [LuaMember("kp3")]
    public readonly int Kp3 = (int)KeyboardKey.Kp3;
    [LuaMember("kp4")]
    public readonly int Kp4 = (int)KeyboardKey.Kp4;
    [LuaMember("kp5")]
    public readonly int Kp5 = (int)KeyboardKey.Kp5;
    [LuaMember("kp6")]
    public readonly int Kp6 = (int)KeyboardKey.Kp6;
    [LuaMember("kp7")]
    public readonly int Kp7 = (int)KeyboardKey.Kp7;
    [LuaMember("kp8")]
    public readonly int Kp8 = (int)KeyboardKey.Kp8;
    [LuaMember("kp9")]
    public readonly int Kp9 = (int)KeyboardKey.Kp9;
    [LuaMember("kpdecimal")]
    public readonly int KpDecimal = (int)KeyboardKey.KpDecimal;
    [LuaMember("kpdivide")]
    public readonly int KpDivide = (int)KeyboardKey.KpDivide;
    [LuaMember("kpmultiply")]
    public readonly int KpMultiply = (int)KeyboardKey.KpMultiply;
    [LuaMember("kpsubtract")]
    public readonly int KpSubtract = (int)KeyboardKey.KpSubtract;
    [LuaMember("kpadd")]
    public readonly int KpAdd = (int)KeyboardKey.KpAdd;
    [LuaMember("kpenter")]
    public readonly int KpEnter = (int)KeyboardKey.KpEnter;
    [LuaMember("kpequal")]
    public readonly int KpEqual = (int)KeyboardKey.KpEqual;

    // MOUSE BUTTONS
    [LuaMember("lmb")]
    public readonly int LMB = (int)MouseButton.Left;
    [LuaMember("rmb")]
    public readonly int RMB = (int)MouseButton.Right;
    [LuaMember("mmb")]
    public readonly int MMB = (int)MouseButton.Middle;
    [LuaMember("back")]
    public readonly int BackMB = (int)MouseButton.Back;
    [LuaMember("forward")]
    public readonly int FrontMB = (int)MouseButton.Forward;
    [LuaMember("side")]
    public readonly int SideMB = (int)MouseButton.Side;
    [LuaMember("extra")]
    public readonly int ExtraMB = (int)MouseButton.Extra;
}