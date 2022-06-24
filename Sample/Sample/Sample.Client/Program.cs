// See https://aka.ms/new-console-template for more information
using Sample.Client;

Console.WriteLine("Hello, World!");
var a = new Test();
//await a.ClientGet();
await a.PassGet();
Console.Read();
