

Hub = function () {
	var self = this;
	var urlGet = "http://prototypeapi-2.apphb.com/api/teams/get/?callback=?";
    self.allTeams = ko.observableArray();
    self.showTeams = ko.observableArray();
    
    self.availableCountries = ko.observableArray(['Colombia', 'Venezuela']);
    self.selectedCountry = ko.observable();

    self.NewTeamName = ko.observable();
    self.NewTeamCity = ko.observable();
	
	$.ajax({
		type: "GET",
		url: urlGet,
		dataType: "jsonp",
		success: function(data) {
			var mappedTeams = $.map(data, function (item) {
            return new TeamViewModel(item);
        });
        self.allTeams(mappedTeams);
		self.showTeams(mappedTeams);
		}, 
	});
	
	self.addNewTeam = function ()
    {
	    if ($('#teamName').val().length >0 && $('#teamValue').val().length >0){
			$('#myModal').modal('hide')
			var newTeam = new Object();
			newTeam.Name = self.NewTeamName;
			newTeam.City = self.NewTeamCity;
			newTeam.Country = self.selectedCountry;
			$.ajax({
				type: "POST",
				url: "http://prototypeapi-2.apphb.com/api/teams/Add",
				data: newTeam,
				dataType: "json"
			});
			self.allTeams.push(new TeamViewModel(newTeam));
			self.changeSelectedToAll();
		}
    }
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
}

// Activates knockout.js

$(document).ready(function () {
    ko.applyBindings(new Hub());
});

TeamViewModel = function(data)
{
	self = this;
	self.Name = data.Name;
	self.City = data.City;
	self.Country = data.Country;
}
