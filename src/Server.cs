using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("Program Entry");

const string HTTP_OK_STATUS_LINE = "HTTP/1.1 200 OK";

TcpListener server = new(IPAddress.Any, 4221);
server.Start();

while (true)
{
    using var socket = await server.AcceptSocketAsync();
    await socket.SendAsync(Encoding.UTF8.GetBytes($"{HTTP_OK_STATUS_LINE}\r\n\r\n"), SocketFlags.None);
}