using DESPDK;

namespace DESPDKExamples2 {
    [PDKExtension]
    public class ExampleTcpSock : PDKAbstractExtension {
        // ID of extension. It mustn't contain spaces and special symbols (for example dots)
        public new string ID = "ExampleTcpSock";
        // Type of extension: 1 - plugin, 2 - addon
        public new int ExtType = 1;
        // Readable name of extension
        public new string Name = "Example Plugin for TCP Socket";
        // Description for extension
        public new string Description = "Just an example";
        // Version of extension
        public new string Version = "1.0.0";
        // Version of DESrv what this extension supports
        public new string DESVersion = "1.0.0";
        // Author of extension
        public new string Author = "Blusutils";
        // Array of dependencies for extension
        //public new string[] Dependencies = Array.Empty<string>();
        // ID of extension to which this extension refers (for addons)
        //public new string Reference = "";

        // Main method
        public override void Entrypoint() {
            Console.WriteLine("Hello DESrv!");
            // Create instance of custom TCP handler
            var a = new OurSockProc("127.0.0.1",11000);
            // Listen for incoming data
            a.Listen();
            // Run socket
            a.Runner();
            // Subscribe
            a.ClientGotDataEvent += (client, data, bytes) => {
                Console.WriteLine(data);
            };
        }

        // Load addon to this extension (for plugins)
        public override void LoadSubExtension(PDKAbstractExtension extension) {
            //extension.Load();
        }

        // Event what calls when extension loads
        public override void Load() {

        }

        // Event what calls when extension unloads
        public override void Unload() {

        }
    }
}