var violationId = sessionStorage.getItem("violationId");

$.ajax({
  url: "/api/violation/" + violationId,
  method: "GET",
  success: function (data) {
    console.log(data);
    // Populate the modal form fields with the retrieved data
    updateViolation(data);
  },
  error: function () {
    alert("Error retrieving violation data");
  }
});

function updateViolation(violationData) {
  // Populate the modal form fields
  $("#updateViolationType").val(violationData.violationType);
  $("#updateViolationDate").val(violationData.violationDate);
  $("#updateViolationTime").val(violationData.violationTime);
  $("#updateOffenseLevel").val(violationData.offenseLevel);
  $("#updateDisciplinaryAction").val(violationData.disciplinaryAction);
  $("#updateOffenseType").val(violationData.offenseType);
  $("#updateLocation").val(violationData.location);
  $("#updateDescription").val(violationData.description);
  $("#updateReportingName").val(violationData.reportingName);
  $("#updateReportingRole").val(violationData.reportingRole);
  $("#updateReportingContact").val(violationData.reportingContact);



  if (violationData.status === "pending") {
    $("#updateStatusPending").prop("checked", true);
  } else if (violationData.status === "ongoing") {
    $("#updateStatusOngoing").prop("checked", true);
  } else if (violationData.status === "resolved") {
    $("#updateStatusResolved").prop("checked", true);
  }

  // Assuming you have a button to trigger the update
  $('#updateViolationForm').submit(function (e) {
    e.preventDefault();
    Swal.fire({
      title: "Are you sure?",
      text: "Do you want to update information of the violation?",
      icon: "warning",
      showCancelButton: true,
      confirmButtonText: "Submit",
    }).then((willSubmit) => {
      if (willSubmit.isConfirmed) {
        updateViolationDataInDatabase(violationData);
      }
    });
  });
}

function updateViolationDataInDatabase(updatedViolation) {
  Swal.fire({
    title: "Are you sure?",
    text: "Do you want to update information of the violation?",
    icon: "warning",
    showCancelButton: true,
    confirmButtonText: "Submit",
  }).then((willSubmit) => {
    if (willSubmit.isConfirmed) {

      var updatedViolation = {
        violationType: $("#updateViolationType option:selected").text(),
        violationDate: $("#updateViolationDate").val(),
        violationTime: $("#updateViolationTime").val(),
        offenseLevel: $("#updateOffenseLevel").val(),
        disciplinaryAction: $("#updateDisciplinaryAction").val(),
        offenseType: $("#updateOffenseType").val(),
        location: $("#updateLocation").val(),
        description: $("#updateDescription").val(),
        reportingName: $("#updateReportingName").val(),
        reportingRole: $("#updateReportingRole").val(),
        reportingContact: $("#updateReportingContact").val(),
        status: $("input[name='approvalStatus']:checked").val(),
      };

      var violationId = sessionStorage.getItem("violationId");

      $.ajax({
        url: `/api/violation/updateviolation/${violationId}`,
        type: "PUT",
        contentType: "application/json",
        data: JSON.stringify(updatedViolation),
        success: function (response) {
    
          console.log(response);
          console.log(updateViolation);

          Swal.fire({
            icon: 'success',
            title: 'Update Successful',
            text: 'Violation information has been updated successfully!',
            timer: 10000,
            willClose: () => {
              window.location.href = 'ViewViolationInfo';
            },
          });
        },
        error: function (error) {
          console.log("Response details:", error.responseText);

          // Handle the error response
          console.error(error);
        }
      });
    }
  });
}


$(document).ready(function () {
  $("#submitbtn").click(function () {
    updateViolationDataInDatabase();
  });
});


document.addEventListener("DOMContentLoaded", function () {
  // Event listeners for changes in violation type and offense level
  document.getElementById("updateViolationType").addEventListener("change", updateDisciplinaryAction);
  document.getElementById("updateOffenseLevel").addEventListener("change", updateDisciplinaryAction);

  // Populate violation options on page load
  populateViolationOptions();
});

function populateViolationOptions() {
  fetch("/api/Violation/getAllViolations")
    .then(response => {
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      return response.json();
    })
    .then(data => {
      console.log("Fetched violations:", data);
      const selectElement = $("#updateViolationType"); // Using jQuery to select the element
      selectElement.empty(); // Clear previous options
      data.forEach(violation => {
        console.log("Processing violation:", violation);
        // Create an option element and append it to the select element
        selectElement.append(`<option value="${violation.id}">${violation.violationName}</option>`);
      });
    })
    .catch(error => {
      console.error('Error fetching violations:', error);
    });
}


function updateDisciplinaryAction() {
  var selectedViolation = document.getElementById("updateViolationType").value;
  var selectedOffenseLevel = document.getElementById("updateOffenseLevel").value;

  if (selectedViolation && selectedOffenseLevel) {
    fetch(`/api/disciplinaryactions?offenselevel=${selectedOffenseLevel}&violationId=${selectedViolation}`)
      .then(response => {
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        return response.json();
      })
      .then(data => {
        const disciplinaryActionInput = document.getElementById("updateDisciplinaryAction");
        // Check if data is an array before joining
        const description = Array.isArray(data) ? data.join(", ") : data;
        disciplinaryActionInput.value = description;
      })
      .catch(error => {
        console.error('Error fetching disciplinary actions:', error);
      });
  }
}
