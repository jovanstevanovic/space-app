function getLaunchesForDateRange(from, to, callback)
{
    var launchUrl = `https://launchlibrary.net/1.4/launch/${from}/${to}?limit=100`;
    $.ajax(launchUrl, {
        method: "GET",
        success: function (result)
        {
            var result1 = result;

            var launchUrl = `http://localhost:49407/Launches/Index?dateFrom=${from}&dateTo=${to}`;
            $.ajax(launchUrl, {
                method: "GET",///saberi
                success: function (result) {
                    for (var i = 0; i < result.launches.length; i++) {
                        result1.launches.push(result.launches[i]);
                        result1.count++;
                    }
                    callback(result1.launches);
                }
            })
        }
    })
}