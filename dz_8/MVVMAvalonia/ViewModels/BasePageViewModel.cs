using System.Collections.ObjectModel;
using MVVMAvalonia.Models;
using ReactiveUI;

namespace MVVMAvalonia.ViewModels
{
    public abstract class BasePageViewModel : ViewModelBase
    {
        protected UsersModel usersModel;
        public string Header => GetName();
        public abstract string GetName();

        protected BasePageViewModel(UsersModel users)
        {
            this.usersModel = users;
            this.users = new ObservableCollection<User>();
            this.users = users.Users;
        }

        private ObservableCollection<User> users;

        public ObservableCollection<User> Users
        {
            get => users;
            set { this.RaiseAndSetIfChanged(ref users, value); }
        }
    }

    public class DataTreeViewModel : BasePageViewModel
    {
        public override string GetName()
        {
            return "DataTreeViewModel";
        }

        public ObservableCollection<Node> Nodes { get; }

        public DataTreeViewModel(UsersModel usersModel) : base(usersModel)
        {
            Nodes = new ObservableCollection<Node>();

            foreach (var user in usersModel.Users)
            {
                Nodes.Add(new Node("ID: " + (user.Id), [
                    new Node("Username: " + user.Username), new Node("Name: " + user.Name),
                    new Node("Email: " + user.Email), new Node("Phone: " + user.Phone),
                    new Node("Website: " + user.Website), new Node("Address: ", [
                        new Node("City: " + user.Address.City), new Node("Street: " + user.Address.Street),
                        new Node("Suite: " + user.Address.Suite), new Node("Code: " + user.Address.Zipcode),
                        new Node("Geo: ",
                            [new Node("Lat: " + user.Address.Geo.Lat), new Node("Lon: " + user.Address.Geo.Lng)])
                    ])
                ]));
            }
        }
    }

    public class DataGridViewModel(UsersModel usersModel) : BasePageViewModel(usersModel)
    {
        public override string GetName()
        {
            return "DataGridViewModel";
        }
    }
}