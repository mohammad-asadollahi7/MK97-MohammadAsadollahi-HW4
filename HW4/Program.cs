using HW4.Model;
using HW4.Repository;

class Program
{
    static void Main()
    {
        UserRepository userRepository = new UserRepository();

        bool continueLoop = false;
        bool continueLoop2 = false;
        do
        {

        } while (continueLoop);

        Console.Write("1.Adding a new user\n2.Viewing the users list\n3.Exist");
        string menuOption = Console.ReadLine();

        switch (menuOption)
        {
            case "1":
                Console.Write("Enter your name: ");
                string Name = Console.ReadLine();

                Console.Write("Enter your mobile phone: ");
                string Mobile = Console.ReadLine();

                Console.Write("Enter your birth day: ");
                DateTime birthDay = Convert.ToDateTime(Console.ReadLine());

                var isValid = userRepository.Create(new User()
                { Name = Name, BirthDay = birthDay, Mobile = Mobile });

                if (isValid)
                    Console.WriteLine("The new user was added successfully.");
                else
                {
                    Console.WriteLine("The input mobile phone is already registered.");
                    continueLoop = true;
                }
                break;

            case "2":
                var users = userRepository.GetAllUsers();

                do
                {
                    foreach (var user in users)
                    {
                        Console.WriteLine(user.ID + " " + user.Name + " "
                                            + user.Mobile + " " + user.BirthDay);
                    }


                    Console.Write("Enter the user ID: ");
                    int targetID = int.Parse(Console.ReadLine());
                    Console.Write("1.Update\n2.Delete");
                    string menuOption2 = Console.ReadLine();

                    switch (menuOption2)
                    {
                        case "1":
                            var updateUser = new User();
                            Console.Write("Enter the new name: ");
                            updateUser.Name = Console.ReadLine();
                            Console.Write("Enter new mobile phone: ");
                            updateUser.Mobile = Console.ReadLine();
                            Console.Write("Enter new birthday: ");
                            updateUser.BirthDay = Convert.ToDateTime(Console.ReadLine());
                            var wasIsUpdated = userRepository.Update(targetID, updateUser);
                            if (wasIsUpdated)
                                Console.WriteLine("The update was done successfully.");
                            else
                            {
                                Console.WriteLine("The ID was not found.");
                                continueLoop2 = true;
                            }
                            break;

                        case "2":
                            var wasItDeleted = userRepository.Delete(targetID);
                            if (wasItDeleted)
                                Console.WriteLine("The delete was done successfully.");
                            else
                            {
                                Console.WriteLine("The ID was not found.");
                                continueLoop2 = true;
                            }
                            break;

                        default:
                            Console.WriteLine("The input is not valid.");
                            continueLoop2 = true;
                            break;
                    }


                } while (continueLoop2);
                break;

            case "3":
                Console.WriteLine("Good bye");
                break;

            default:
                Console.WriteLine("The input is not valid.");
                continueLoop = true;
                break;
        }




    }
}
