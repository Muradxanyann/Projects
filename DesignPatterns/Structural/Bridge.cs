namespace StructuralTask2
{
    interface IPaymentProcessor
    {
        void Process();
    }

    class StripeProcessor : IPaymentProcessor
    {
        public void Process() => Console.WriteLine("Payment from stripe is in proccess...");
    }
    class PayPalProcessor : IPaymentProcessor
    {
        public void Process() => Console.WriteLine("Payment from PayPal is in proccess...");
    }
    class CryptoWalletProcessor : IPaymentProcessor
    {
        public void Process() => Console.WriteLine("Payment from Cripto wallet is in proccess...");
    }

    abstract class Payment
    {
        protected IPaymentProcessor paymentProcessor;
        protected Payment (IPaymentProcessor paymentProcessor) => this.paymentProcessor = paymentProcessor;

        public abstract void Pay();
    }

    class BasicPayment : Payment
    {
        public BasicPayment(IPaymentProcessor paymentProcessor) : base (paymentProcessor) {}
        public override void Pay() => paymentProcessor.Process();
        
    }

    class SubscriptionPayment : Payment
    {
        public SubscriptionPayment(IPaymentProcessor paymentProcessor) : base (paymentProcessor) {}
        public override void Pay() => paymentProcessor.Process();
    }
    
}