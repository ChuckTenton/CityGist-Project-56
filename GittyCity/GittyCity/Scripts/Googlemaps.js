function initialize(cor) {
    var mapProp = {
        center: new google.maps.LatLng(cor),
        zoom: 5,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById("google"), mapProp);
    var map2 = new google.maps.Map(document.getElementById("google2"), mapProp);
}
google.maps.event.addDomListener(window, 'load', initialize);
