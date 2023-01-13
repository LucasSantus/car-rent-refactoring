function isLoading(value) {
  const loading = $("#loading-container");

  if (value) {
    loading.removeClass("d-none");
  } else {
    setTimeout(() => {
      loading.addClass("d-none");
    }, 1000);
  }
}

class Request {
  constructor(baseUrl) {
    this.baseUrl = baseUrl;
  }
  get(endpoint, callback, params) {
    this.JQueryBaseRequest(endpoint, "GET", callback, params);
  }

  post(endpoint, callback, params) {
    this.JQueryBaseRequest(endpoint, "POST", callback, params);
  }

  JQueryBaseRequest(endpoint, type, callback, params) {
    isLoading(true);

    setTimeout(() => {
      $.ajax({
        url: this.baseUrl + endpoint,
        type: type,
        data: JSON.stringify(params),
        dataType: "json",
        timeout: 10000,
        contentType: "application/json; charset=utf-8",
        success: function (response) {
          callback(response);
        },
        error: function () {
          callback([]);

          console.log("Ocorreu uma falha na requisição | " + endpoint);
        },
      });
    }, 1000);

    isLoading(false);
  }
}
