/* Task 9:
Create a system for building customized Computer objects where users can choose CPU, 
RAM, storage, and GPU step by step. */

namespace Task9
{
    class Computer
    {
        public string? Cpu { get; set; }
        public string? Ram { get; set; }

        public string? Ssd { get; set; }

        public string? Gpu { get; set; }

        public override string ToString() => $"Computer with following parapeters {Cpu},  {Ram}, {Ssd},  {Gpu}";
    }

    interface ICompBuilder
    {
        void CpuBuilder();
        void RamBuilder();
        void SsdBuilder();
        void GpuBuilder();
        Computer GetComputer();
    }

    class AdvancedCompBuilder : ICompBuilder
    {
        private  Computer _computer = new();

        public void CpuBuilder() => _computer.Cpu = "Intel Core i9";
        public void GpuBuilder() => _computer.Gpu = "NVIDIA RTX 4090";
        public void RamBuilder() => _computer.Ram = "32GB DDR5";
        public void SsdBuilder() => _computer.Ssd = "1TB NVMe";

        public Computer GetComputer()
        {
            var comp = _computer;
            _computer = new();
            return comp;
        }
    }

    class Director
    {
        private readonly ICompBuilder _computer;
        public Director(ICompBuilder computer) => _computer = computer;

        public void BuildComputer()
        {
            _computer.CpuBuilder();
            _computer.GpuBuilder();
            _computer.RamBuilder();
            _computer.SsdBuilder();
        }
    }

   
}