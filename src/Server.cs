using System.Net;
using System.Net.Sockets;
using System.Text;

const string HTTP_OK_STATUS_LINE = "HTTP/1.1 200 OK";

TcpListener server = new(IPAddress.Any, 4221);
server.Start();

while (true)
{
    Console.WriteLine("Waiting For Incoming Connections On 127.0.0.1:4221");

    using var socket = await server.AcceptSocketAsync();
    await Task.Delay(1000);
    Console.WriteLine("Client Connected!");

    await socket.SendAsync(Encoding.UTF8.GetBytes($"{HTTP_OK_STATUS_LINE}\r\n\r\n"), SocketFlags.None);
    Console.WriteLine("Response Sent!");
}