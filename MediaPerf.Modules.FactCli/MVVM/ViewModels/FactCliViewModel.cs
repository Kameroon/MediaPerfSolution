using MediaPerf.Infrastructure.Communs;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaPerf.Modules.FactCli.MVVM.ViewModels
{
    public class FactCliViewModel : ViewModelBase
    {
        #region Fields

        #endregion

        #region Attributes   
        public ICommand ValidateCommand { get; private set; }
        public ICommand BrowseCommand { get; private set; }
        public ICommand CopyItemCommand { get; private set; }
        public ICommand DeleteItemCommand { get; private set; }
        #endregion

        #region Properties

        #endregion

        #region Constructor
        public FactCliViewModel()
        {
            Initialize();
        }
        #endregion

        private ObservableCollection<Person> _people;

        public ObservableCollection<Person> PersonList
        {
            get { return _people; }
            set
            {
                SetProperty(ref _people, value);
            }
        }

        private Person _selectedPeople;

        public Person SelectedPerson
        {
            get { return _selectedPeople; }
            set
            {
                SetProperty(ref _selectedPeople, value);
            }
        }

        #region Methods
        private void Initialize()
        {

            ValidateCommand = new DelegateCommand(OnWindow, CanWindow);
            BrowseCommand = new DelegateCommand(OnBrowse, CanBrowse);

            CopyItemCommand = new DelegateCommand(CopyItem, CanWindow);
            DeleteItemCommand = new DelegateCommand(DeleteItem, () => true);

            //People people = new People();
            PersonList = People.GetPoeple();
        }

        private void CopyItem()
        {
            var people = SelectedPerson?.Name;
        }

        private void DeleteItem()
        {
            
        }

        private bool CanBrowse()
        {
            return true;
        }

        private void OnBrowse()
        {
            Console.WriteLine("Brower .......................");
        }

        private void OnWindow()
        {
            Console.WriteLine("Validate 1000000000000000000000000");
        }

        private bool CanWindow()
        {
            return true;
        }
        #endregion

        #region ------  ------
        //data source

        public class Person
        {
            public int Age { get; set; }
            public string Gender { get; set; }
            public string Name { get; set; }
            public string SecNumber { get; set; }
        }

        //add a bunch of Person to a collection
        public class People : ObservableCollection<Person>
        {
            public People()
            {
                //for (int i = 1; i < 10; i++)
                //{
                //    if (i < 5)
                //    {
                //        this.Add(new Person()
                //        {
                //            Age = i, Gender = "Female", Name = "Name" + i, SecNumber = "SecNumber" + i
                //        });
                //    }
                //    else if (i < 8)
                //    {
                //        this.Add(new Person()
                //        {
                //            Age = i, Gender = "Male", Name = "Name" + i, SecNumber = "SecNumber" + i
                //        });
                //    }
                //    else this.Add(new Person()
                //    {
                //        Age = i, Gender = "Female", Name = "Name" + i, SecNumber = "SecNumber" + i
                //    });
                //}
            }

            public static ObservableCollection<Person> GetPoeple()
            {
                var peoples = new ObservableCollection<Person>();

                for (int i = 1; i < 15; i++)
                {
                    if (i < 5)
                    {
                        peoples.Add(new Person()
                        {
                            Age = i,
                            Gender = "Female",
                            Name = "Name" + i,
                            SecNumber = "SecNumber" + i
                        });
                    }
                    else if (i < 8)
                    {
                        peoples.Add(new Person()
                        {
                            Age = i,
                            Gender = "Male",
                            Name = "Name" + i,
                            SecNumber = "SecNumber" + i
                        });
                    }
                    else peoples.Add(new Person()
                    {
                        Age = i,
                        Gender = "Female",
                        Name = "Name" + i,
                        SecNumber = "SecNumber" + i
                    });
                }

                return peoples;
            }

        }

        //customized sorter
        public class PersonSorter : System.Collections.IComparer
        {
            public int Compare(object x, object y)
            {
                Person lhs = (Person)x;
                Person rhs = (Person)y;
                // Sort Name ascending and Age descending
                int nameCompare = lhs.Name.CompareTo(rhs.Name);
                if (nameCompare != 0) return nameCompare;
                return rhs.Age - lhs.Age;
            }
        }
        #endregion
    }
}
