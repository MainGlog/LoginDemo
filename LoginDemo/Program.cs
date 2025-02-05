namespace LoginDemo
{
    public class Program
    {
        private enum Action
        {
            Login, Register, Exit
        }

        public const String PEPPER = "Hn6D9kl";
        private static List<User> users = [];
        public static void Main()
        {
            Action currentAction = GetAction();

            while(currentAction != Action.Exit)
            {
            }
        }
        private static Action GetAction()
        {
            // Every label defined in the enum will be a string that can be referenced in the array
            String[] validActions = Enum.GetNames(typeof(Action));

            // Initial input
            Console.Write("Choose an action: ");
            Console.WriteLine(String.Join(", ", validActions));
            String action = Console.ReadLine()!;

            // Input validation
            while(validActions.Contains(action) == false)
            {
                Console.Error.WriteLine("Invalid action. Please try again.");
                Console.Write("Choose an action: ");
                Console.WriteLine(String.Join(", ", validActions));
                action = Console.ReadLine()!;
            }
            // Cast the string back to an enum
            return (Action)Enum.Parse(typeof(Action), action);
        }

        private static void Register()
        {
            Console.Write("Enter your email: ");
            String email = Console.ReadLine()!;

            while(users.Any(user => user.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
            {
                Console.Error.WriteLine("Email already exists.");
                Console.Write("Enter your email: ");
                email = Console.ReadLine()!;
            }

            Console.Write("Enter your password: ");
            String password = Console.ReadLine()!;

            users.Add(new User(email, password));
            Console.WriteLine("User registered successfully.");
        }
    }
}
