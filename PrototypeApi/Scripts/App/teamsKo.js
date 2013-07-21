AppViewModel = function () {
    var self = this;
    self.allTeams = ko.observableArray();
    self.showTeams = ko.observableArray();

    
    self.availableCountries = ko.observableArray(['Colombia', 'Venezuela']);
    self.selectedCountry = ko.observable();

    self.NewTeamName = ko.observable();
    self.NewTeamCity = ko.observable();

    $.getJSON("/Teams/Get", function (data) {
        var mappedTeams = $.map(data.teams, function (item) {
            return new TeamViewModel(item);
        });
        self.allTeams(mappedTeams);
        self.showTeams(mappedTeams);
    });

    self.changeSelectedToVenezuela = function ()
    {
        self.showTeams(ko.utils.arrayFilter(self.allTeams(), function (data) {
            return data.Country === 'Venezuela';
        }));
    }

    self.changeSelectedToColombia = function () {
        self.showTeams(ko.utils.arrayFilter(self.allTeams(), function (data) {
            return data.Country === 'Colombia';
        }));
    }

    self.changeSelectedToAll = function () {
        self.showTeams(self.allTeams);
    }

    self.addNewTeam = function ()
    {
        var newTeam = new Object();
        newTeam.Name = self.NewTeamName;
        newTeam.City = self.NewTeamCity;
        newTeam.Country = self.selectedCountry;
        $.ajax({
            type: "POST",
            url: "/Teams/Add",
            data: newTeam,
            dataType: "Json"
        });
    }
}

$(document).ready(function () {
    ko.applyBindings(new AppViewModel());
});

TeamViewModel = function (data) {
    self = this;
    self.Id = data.Id;
    self.Name = data.Name;
    self.City = data.City;
    self.Country = data.Country;
}