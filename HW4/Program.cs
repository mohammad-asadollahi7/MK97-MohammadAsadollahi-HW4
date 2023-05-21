using HW4.Model;
using HW4.Repository;

class Program
{
    static void Main()
    {
        UserRepository userRepository = new UserRepository();
        bool continueLoop = false;
        bool continueLoop2 = false;
        string menuOption1;
        string menuOption2;
        int targetID;
        User user = new User();
        User updateUser = new User();
        List<User> users;

        do
        {
            Console.Clear();
            Console.Write("Please enter the number of option:\n" +
                             "1.Adding a new user\n2.Viewing the users list\n3.Exist\n");
            menuOption1 = Console.ReadLine();

            switch (menuOption1)
            {
                case "1":
                    Console.Write("Enter the name: ");
                    user.Name = Console.ReadLine();

                    Console.Write("Enter the mobile phone: ");
                    user.Mobile = Console.ReadLine();

                    Console.Write("Enter the birthday(yyyy-MM-dd): ");
                    user.BirthDay = Convert.ToDateTime(Console.ReadLine());

                    var isValid = userRepository.Create(user);

                    if (isValid)
                        Console.WriteLine("The new user was added successfully.");
                    else
                    {
                        Console.WriteLine("The input mobile phone is already registered.");
                        continueLoop = true;
                    }
                    break;

                case "2":

                    users = userRepository.GetAllUsers();
                    do
                    {
                        foreach (var u in users)
                        {
                            Console.WriteLine("ID:" + u.ID + " Name:" + u.Name + " Mobile:"
                                                + u.Mobile + " Birthday:" + 
                                                u.BirthDay.ToString("dd/MM/yyyy"));
                        }

                        Console.Write("Enter the user ID: ");
                        targetID = int.Parse(Console.ReadLine());
                        Console.Write("1.Update\n2.Delete\n");
                        menuOption2 = Console.ReadLine();

                        switch (menuOption2)
                        {
                            case "1":
                                Console.Write("Enter the new name: ");
                                updateUser.Name = Console.ReadLine();
                                Console.Write("Enter new mobile phone: ");
                                updateUser.Mobile = Console.ReadLine();
                                Console.Write("Enter new birthday(yyyy-MM-dd): ");
                                updateUser.BirthDay = Convert.ToDateTime(Console.ReadLine());
                                var wasIsUpdated = userRepository.Update(targetID, updateUser);
                                if (wasIsUpdated)
                                    Console.WriteLine("The update was done successfully.");
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("The ID was not found.\n");
                                    continueLoop2 = true;
                                }
                                break;

                            case "2":
                                var wasItDeleted = userRepository.Delete(targetID);
                                if (wasItDeleted)
                                    Console.WriteLine("The delete was done successfully.");
                                else
                                {
                                    Console.Clear();
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

        } while (continueLoop);
    }
}
