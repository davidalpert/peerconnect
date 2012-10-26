class window.NewSesionViewModel

	constructor: ->
		$('#users li a').on 'click', @loginUser

	loginUser: (e) ->
		userId = $(e.target).attr('data-id')
		$.post "/login", {id: userId}, (data) -> window.location.replace("/");
		

$ ->
	new window.NewSesionViewModel()