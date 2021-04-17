using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2
{
    class ContactDBMock : DataAccessLayer
    {
        List<ContactDTO> contacts = new List<ContactDTO>();
        public string CreateContact(ContactDTO contact)
        {
            contacts.Add(contact);
            return contact.Id;
        }

        public bool DelecteContactById(string id)
        {
            ContactDTO contact = contacts.Find(x => x.Id == id);
            if (contact != null)
            {
                contacts.Remove(contact);
                return true;
            }
            return false;
        }

        public List<ContactDTO> GetAllContacts()
        {
            return contacts;
        }

        public ContactDTO GetContactById(string id)
        {
            return contacts.Find(x => x.Id == id);
        }
    }
}
