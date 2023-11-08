using System.Net;
using System.Net.Sockets;
using System.Text;
using Pomelo;
using Task1.source;


public class Program
{
    async public static Task Main()
    {
        var tcpListener = new TcpListener(IPAddress.Any, 8888);

        tcpListener.Start();
        try
        {
            while (true)
            {
                using var tcpClient = await tcpListener.AcceptTcpClientAsync();
                var stream = tcpClient.GetStream();
                byte[] data = new byte[256];
                await stream.ReadAsync(data);
                var s = Encoding.UTF8.GetString(data);
                using (var context = new StockContext())
                {
                    var ticker = context.Tickers.FirstOrDefault(t => t.TickerName == s);
                    var price = context.Prices.FirstOrDefault(p => p.ID == ticker.Id);
                    await stream.WriteAsync(Encoding.UTF8.GetBytes(Convert.ToString(price)));
                }
            }
        }
        finally
        {
            tcpListener.Stop();
        }

        
    }
}