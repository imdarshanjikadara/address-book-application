using System;
using System.Collections.Generic;

class Contact
{
    // Properties to hold contact's name and email
    public string Name { get; set; }
    public string Email { get; set; }

    // Constructor to initialize a new contact with a name and email
    public Contact(string name, string email)
    {
        Name = name;
        Email = email;
    }
}

class Program
{
    // A static list to hold all contacts
    static List<Contact> contacts = new List<Contact>();

    // Method to view all contacts
    static void ViewContacts()
    {
        Console.Clear();
        Console.WriteLine("Contacts:");

        // Check if there are no contacts and inform the user
        if (contacts.Count == 0)
        {
            Console.WriteLine("No contacts found");
        }
        else
        {
            // Display each contact with its index
            for (int i = 0; i < contacts.Count; i++)
            {
                Console.WriteLine("{0}. {1} ({2})", i + 1, contacts[i].Name, contacts[i].Email);
            }
        }
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    // Method to add a new contact
    static void AddContacts()
    {
        Console.Clear();
        Console.WriteLine("Add Contact");
        
        // Prompt user for contact name
        Console.Write("Name: ");
        string? name = Console.ReadLine();
        if (string.IsNullOrEmpty(name))
        {
            // Inform user if name is empty
            Console.WriteLine("Name can't be empty");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }

        // Prompt user for contact email
        Console.Write("Email: ");
        string? email = Console.ReadLine();
        if (string.IsNullOrEmpty(email))
        {
            // Inform user if email is empty
            Console.WriteLine("Email can't be empty");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }

        // Create a new contact and add it to the list
        contacts.Add(new Contact(name, email));
        Console.WriteLine("Contact added successfully");
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    // Method to edit an existing contact
    static void EditContact()
    {
        Console.Clear();
        Console.WriteLine("Edit Contact");

        // Check if there are no contacts and inform the user
        if (contacts.Count == 0)
        {
            Console.WriteLine("No contacts found");
        }
        else
        {
            // Display each contact with its index
            for (int i = 0; i < contacts.Count; i++)
            {
                Console.WriteLine("{0}. {1} ({2})", i + 1, contacts[i].Name, contacts[i].Email);
            }
        }
        
        // Prompt user for the index of the contact to edit
        Console.Write("Enter contact number to edit: ");
        string? input = Console.ReadLine();
        if (input == null || !int.TryParse(input, out int index) || index < 1 || index > contacts.Count)
        {
            // Inform user if the input is invalid
            Console.WriteLine("Invalid contact number.");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }

        index--;

        // Retrieve the selected contact
        Contact contact = contacts[index];

        // Prompt user for new name and email, or use existing values if input is empty
        Console.Write("Name ({0}): ", contact.Name);
        string? name = Console.ReadLine();
        if (string.IsNullOrEmpty(name))
        {
            name = contact.Name; // Keep the old name if the new one is empty
        }

        Console.Write("Email ({0}): ", contact.Email);
        string? email = Console.ReadLine();
        if (string.IsNullOrEmpty(email))
        {
            email = contact.Email; // Keep the old email if the new one is empty
        }

        // Update the contact's properties with new values
        contact.Name = name;
        contact.Email = email;

        Console.WriteLine("Contact updated successfully");
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    // Method to delete a contact
    static void DeleteContacts()
    {
        Console.Clear();
        Console.WriteLine("Delete Contact");

        // Check if there are no contacts and inform the user
        if (contacts.Count == 0)
        {
            Console.WriteLine("No contacts found");
        }
        else
        {
            // Display each contact with its index
            for (int i = 0; i < contacts.Count; i++)
            {
                Console.WriteLine("{0}. {1} ({2})", i + 1, contacts[i].Name, contacts[i].Email);
            }
        }

        // Prompt user for the index of the contact to delete
        Console.Write("Enter contact number to delete: ");
        string? input = Console.ReadLine();
        if (input == null || !int.TryParse(input, out int index) || index < 1 || index > contacts.Count)
        {
            // Inform user if the input is invalid
            Console.WriteLine("Invalid contact number.");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }

        index--;

        // Remove the selected contact from the list
        contacts.RemoveAt(index);

        Console.WriteLine("Contact deleted successfully");
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void Main(string[] args)
    {
        bool exit = false;
        while(!exit)
        {
            Console.Clear();
            Console.WriteLine("Address Book");
            Console.WriteLine("1. View Contacts");
            Console.WriteLine("2. Add Contact");
            Console.WriteLine("3. Edit Contact");
            Console.WriteLine("4. Delete Contact");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            
            // Read and convert the user's choice
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                continue;
            }

            // Execute the chosen action
            switch (choice)
            {
                case 1:
                    ViewContacts();
                    break;
                case 2:
                    AddContacts();
                    break;
                case 3:
                    EditContact();
                    break;
                case 4:
                    DeleteContacts();
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
