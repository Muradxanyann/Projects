    using System.Runtime.InteropServices;

    namespace StructuralTask5
    {
        class Cpu
        {
            public void Freeze() => Console.WriteLine("Freezeeng CPU");
            public void Execute() => Console.WriteLine("Executing CPU");
        }
        class Memory
        {
            public void Load(int address) => Console.WriteLine($"Loading Memory at address {address}");
        }

        class HardDrive
        {
            public void Read(int sector, int size) => Console.WriteLine($"Hard Drive reading sector {sector} (size {size})");
        }

        class Gpu
        {
            public void Initialize() => Console.WriteLine("GPU initializing...");
        }

        class ComputerFacade
        {
            private readonly Cpu cpu;
            private readonly Memory memory;

            private readonly HardDrive hardwareDrive;

            private readonly Gpu gpu;

            public ComputerFacade()
            {
                this.cpu = new Cpu();
                this.memory = new Memory();
                this.hardwareDrive = new HardDrive();
                this.gpu = new Gpu();
            }
            public void StartComputer()
            {
                cpu.Freeze();
                memory.Load(0);
                hardwareDrive.Read(0, 1024);
                gpu.Initialize();
                cpu.Execute();
            }
        }

    }