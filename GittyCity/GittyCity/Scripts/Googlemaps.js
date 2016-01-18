function initialize(cor) {
    var LatLng = new google.maps.LatLng(52.1989253712296, 4.4717221099318);

    var mapProp = {
        center: LatLng,
        zoom: 17,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById("google"), mapProp);

    var marker = new google.maps.Marker({
        position: LatLng,
        map: map,
        title: 'Hello World!'
    });
}
google.maps.event.addDomListener(window, 'load', initialize);
