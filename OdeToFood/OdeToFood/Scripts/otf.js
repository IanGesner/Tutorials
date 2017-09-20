$(function () {
    var ajaxFormSubmit = function () {
        var $form = $(this);

        //build an options object from the form
        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize() // since this is a search, we will only send the search term
            // but there could be additional data here as well
        };

        //$.ajax is one way to make an asynchronous call to the server
        //passing options into the parameter tells jQuery where to call, what http verb to use,
        //and give it the data
        //.done is a callback function. When that request is complete, the response from the server
        //will be in the data variable
        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-otf-target"));
            var $newHtml = $(data);
            $target.replaceWith($newHtml);
            $newHtml.effect("highlight");
        });
        //the target variable represents the DOM element on the page that I want to update
        //replace will replace that target with the HTML response from the server

        //returning false prevents the browser from doing it's default action - navigating away
        //and doing a full page refresh
        return false;
    };


    var submitAutocompleteForm = function (event, ui) {
        var $input = $(this);
        $input.val(ui.item.label);

        var $form = $input.parents("form:first");
        $form.submit();
    }

    var createAutocomplete = function () {
        var $input = $(this);

        var options = {
            source: $input.attr("data-otf-autocomplete"),
            select: submitAutocompleteForm
        };

        $input.autocomplete(options);
    }

    var getPage = function () {
        var $a = $(this);

        var options = {
            url: $a.attr("href"), //this will pull the URL out of the href tag in <a href="url"> for the next or prev button
            data: $("form").serialize(), //necessary for paging to work after searching
            type: "get"           //just says it's a get request
        };

        $.ajax(options).done(function (data) {
            var target = $a.parents("div.pagedList").attr("data-otf-target");
            $(target).replaceWith(data);
        });

        return false;
    }

    $("form[data-otf-ajax='true']").submit(ajaxFormSubmit);
    $("input[data-otf-autocomplete]").each(createAutocomplete);

    //we destroy the prev/next anchor tags every time we repaint the screen
    //would have to rewire the event every time we drew screen like that if 
    //we were to just wire up the .onClick even with jQuery
    $(".body-content").on("click", ".pagedList a", getPage);
});