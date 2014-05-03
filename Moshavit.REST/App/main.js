requirejs.config({
    baseUrl: '/App',
    paths: {
        "text": "../Scripts/text",
        "durandal": "../Scripts/durandal",
        "plugins": "../Scripts/durandal/plugins",
        "transitions": "../Scripts/durandal/transitions",
    }
});

define('jquery', function () { return jQuery; });
define('knockout', ko);

define(['durandal/app', 'durandal/system', 'durandal/viewLocator'],
    function (app, system, viewLocator) {

        system.debug(true);
        app.title = "Administrator Tool";

        app.configurePlugins({
            router: true,
            dialog: true
        });

        app.start().then(function () {

            viewLocator.useConvention();

            app.setRoot("viewmodels/login");
        });

    });