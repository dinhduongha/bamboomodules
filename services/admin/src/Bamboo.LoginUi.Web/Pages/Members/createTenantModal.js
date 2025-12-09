var abp = abp || {};

abp.modals.createTenantModal = function () {
  var initModal = function (publicApi, args) {
    console.log("createTenantModal initialized");
  };

  var saveModal = function (publicApi) {
    console.log("CreateTenantModal save triggered");
    var form = $("#createTenantForm");

    if (!form.valid()) {
      // nếu dùng jquery.validate
      return false; // chặn submit
    }

    return true; // ABP tự submit AJAX
  };

  return {
    initModal: initModal,
    saveModal: saveModal,
  };
};
