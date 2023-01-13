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

function convertSerializeToJSON($form) {
  const serialized = $form.serializeArray();
  const indexed_array = {};

  $.map(serialized, function (item) {
    indexed_array[item["name"]] = item["value"];
  });

  return indexed_array;
}

function validationForm() {
  "use strict";

  // Fetch all the forms we want to apply custom Bootstrap validation styles to
  var forms = document.querySelectorAll(".needs-validation");

  // Loop over them and prevent submission
  Array.prototype.slice.call(forms).forEach(function (form) {
    form.addEventListener(
      "submit",
      function (event) {
        if (!form.checkValidity()) {
          event.preventDefault();
          event.stopPropagation();
        }

        form.classList.add("was-validated");
      },
      false
    );
  });
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
