namespace BehaviouralTask1
{
    class SupportTicket
    {
        public string IssueType { get; private set; }
        public string Description { get; private set; }

        public SupportTicket(string issueType, string description)
        {
            IssueType = issueType;
            Description = description;
        }
    }

    abstract class SupportHandler
    {
        protected SupportHandler? nextHandler;
        public SupportHandler SetNext(SupportHandler handler) => nextHandler = handler;

        public abstract void Handle(SupportTicket ticket);

        public abstract bool CanHandle(SupportTicket ticket);


    }

    class BillingSupport : SupportHandler
    {
        public override bool CanHandle(SupportTicket ticket) => ticket.IssueType.ToLower() == "builling";

        public override void Handle(SupportTicket ticket)
        {
            if (CanHandle(ticket))
            {
                Console.WriteLine($"Billing Support handled the issue: {ticket.Description} ");
            }
            else
            {
                nextHandler?.Handle(ticket);
            }
        }

    }
    class TechnicalSupport : SupportHandler
    {
        public override bool CanHandle(SupportTicket ticket) => ticket.IssueType.ToLower() == "technical";

        public override void Handle(SupportTicket ticket)
        {
            if (CanHandle(ticket))
            {
                Console.WriteLine($"Technical Support handled the issue: {ticket.Description} ");
            }
            else
            {
                nextHandler?.Handle(ticket);
            }
        }

    }

    class GeneralSupport : SupportHandler
    {
        public override bool CanHandle(SupportTicket ticket) => true;

        public override void Handle(SupportTicket ticket)
        {
            Console.WriteLine($"General Support handled the issue: {ticket.Description} ");
        }
    }

    


}