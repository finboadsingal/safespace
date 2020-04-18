using System;
using System.Collections.Generic;

namespace SafeSpace
{
    public class User
    {
        private string _id;
        private bool _noTiredness;
        private bool _noCough;
        private bool _noTroubleBreathing;
        private bool _noFever;
        private bool _testedPositive;
        private int _daysInQuarantine;

        public User(string email, bool NoTiredness, bool NoCough, bool NoTroubleBreathing, bool NoFever, int DaysInQuarantine)
        {
            _id = email;
            _noTiredness = NoTiredness;
            _noCough = NoCough;
            _noTroubleBreathing = NoTroubleBreathing;
            _noFever = NoFever;
            _daysInQuarantine = DaysInQuarantine;

            this.Contacts = new List<User>();
        }
        public List<User> Contacts { get; set; }
        public void AddToContacts(User user)
        {
            this.Contacts.Add(user);
        }
        public string SafeStatus()
        {
            string contactWithOthers = ContactWithInfectedPerson();
            if (((BeenInQurantine() && NoSymptoms()) || TestedNegative()) && contactWithOthers == "Green")
                return "Green";
            else if (WentOutInPublic() || contactWithOthers == "Red" || TestedPositive())
                return "Red";
            else if (!BeenInQurantine() || !NoSymptoms() || contactWithOthers == "Yellow")
                return "Yellow";
            return "neutral";
        }

        private bool TestedPositive()
        {
            return false;
        }

        private bool NoSymptoms()
        {
            if (NoFever() && NoTroubleBreathing() && NoCough() && NoTiredness())
                return true;
            else
                return false;
        }

        private bool NoTiredness()
        {
            if (_noTiredness) return true;
            else return false;
        }

        private bool NoCough()
        {
            if (_noCough) return true;
            else return false;
        }

        private bool NoTroubleBreathing()
        {
            if (_noTroubleBreathing) return true;
            else return false;
        }

        private bool NoFever()
        {
            if (_noFever) return true;
            else return false;
        }

        private bool IsAtRisk()
        {
            if (WentOutInPublic())
                return true;
            string risk = ContactWithInfectedPerson();
            if (risk == "Red") return true;
            return false;
        }

        private string ContactWithInfectedPerson()
        {
            bool hasYellow = false;
            foreach(var user in Contacts)
            {
                string userStatus = user.SafeStatus();
                if (userStatus == "Red")
                {
                    return "Red";
                } else if (userStatus == "Yellow")
                {
                    hasYellow = true;
                }
            }
            if (hasYellow) return "Yellow";
            return "Green";
        }

        private bool WentOutInPublic()
        {
            return false;
        }

        private bool IsSafe()
        {
            if ((BeenInQurantine() && NoSymptoms()) || TestedNegative())
            {
                return true;
            }
            else return false;
        }

        private bool TestedNegative()
        {
            return false;
        }

        private bool BeenInQurantine()
        {
            if (_daysInQuarantine >= 14)
                return true;
            else return false;
        }
    }
}
