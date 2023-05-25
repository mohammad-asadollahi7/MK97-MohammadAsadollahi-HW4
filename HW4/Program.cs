using HW4.DataAccess;
using HW4.Model;
using HW4.Repository;
using HW4.User_Defined_Exceptions;

class Program
{
    static void Main()
    {
        UserRepository userRepository = new UserRepository(new CSVAccess());
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
            try
            {
                Console.Write("Please enter the number of option:\n" +
                                 "1.Adding a new user\n" +
                                 "2.Viewing the users list\n3.Exist\n");
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
                        {
                            Console.Clear();
                            Console.WriteLine("The new user was added successfully.");
                            Console.WriteLine("Do you want to back menu(y/n): ");
                            string temp = Console.ReadLine();
                            Console.Clear();
                            if (temp == "y")
                                continueLoop = true;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("The input mobile phone is already registered.");
                            continueLoop = true;
                        }
                        break;

                    case "2":

                        users = userRepository.GetAllUsers();
                        do
                        {
                            Console.Clear();
                            foreach (var u in users)
                            {
                                Console.WriteLine("ID:" + u.ID + " Name:" + u.Name + " Mobile:"
                                                    + u.Mobile + " Birthday:" +
                                                    u.BirthDay.ToString("dd/MM/yyyy"));
                            }

                            Console.Write("Enter the user ID: ");
                            targetID = int.Parse(Console.ReadLine());
                            Console.Clear();
                            Console.Write("1.Update\n2.Delete\n3.Back\n");
                            menuOption2 = Console.ReadLine();

                            switch (menuOption2)
                            {
                                case "1":
                                    Console.Write("Enter updated name: ");
                                    updateUser.Name = Console.ReadLine();
                                    Console.Write("Enter updated mobile phone: ");
                                    updateUser.Mobile = Console.ReadLine();
                                    Console.Write("Enter updated birthday(yyyy-MM-dd): ");
                                    updateUser.BirthDay = Convert.ToDateTime(Console.ReadLine());
                                    var wasIsUpdated = userRepository.Update(targetID, updateUser);
                                    if (wasIsUpdated)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("The update was done successfully.");
                                        Console.WriteLine("Do you want to back menu(y/n): ");
                                        string temp = Console.ReadLine();
                                        Console.Clear();
                                        if (temp == "y")
                                            continueLoop = true;
                                    }

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
                                    {
                                        Console.Clear();
                                        Console.WriteLine("The delete was done successfully.");
                                        Console.WriteLine("Do you want to back menu(y/n): ");
                                        string temp = Console.ReadLine();
                                        Console.Clear();
                                        if (temp == "y")
                                            continueLoop = true;
                                    }

                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("The ID was not found.");
                                        continueLoop2 = true;
                                    }
                                    break;

                                case "3":
                                    Console.Clear();
                                    continueLoop2 = false;
                                    continueLoop = true;
                                    break;

                                default:
                                    Console.Clear();
                                    Console.WriteLine("The input is not valid.");
                                    continueLoop2 = true;
                                    break;
                            }


                        } while (continueLoop2);
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Good bye");
                        continueLoop = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("The input is not valid.");
                        continueLoop = true;
                        break;
                }
            }

            catch (InvaildBirthDay ex)
            {
                Console.Clear();
                Console.Write(ex.Message);
                continueLoop = true;
            }
            catch (InvalidPhoneFormat ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                continueLoop = true;
            }
            catch (FormatException ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                continueLoop = true;
            }
        } while (continueLoop);
       
    }
}
