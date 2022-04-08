using Hw2.Exercise3;
using Hw2.Exercise3.Plugins;

var app = new CliApplication(new[] { new EchoPlugin() });
return (int)app.Run(args);
