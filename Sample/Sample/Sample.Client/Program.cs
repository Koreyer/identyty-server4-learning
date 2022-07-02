// See https://aka.ms/new-console-template for more information
using Sample.Client;

Console.WriteLine("Hello, World!");
await ClientTest.ClientGet();
await ClientTest.PassGet();
Console.ReadLine();
