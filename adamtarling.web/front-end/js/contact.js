$(function () {
    var contact = new Contact();
});

function Contact() {
    var self = this;

    self.contactFormWrapper = $('#contactFormWrapper').find('#contactForm');
    self.contactForm = $(contactFormWrapper).find('#contactForm');
    self.contactFormName = $(contactForm).find('#name');
    self.IsContactFormNameValid = false;
    self.contactFormEmail = self.contactForm.find('#email');
    self.IsContactFormEmailValid = false;
    self.contactFormPhone = self.contactForm.find('#phone');
    self.IsContactFormPhoneValid = false;
    self.contactFormMessage = self.contactForm.find('#message');
    self.IsContactFormMessageValid = false;
    self.contactFormSubmitButton = $(contactFormWrapper).find('#contactSubmit');
    self.contactFormSubmitUrl = '/umbraco/surface/contactsurface/submit';
    self.successMessage = $(contactFormWrapper).find('.successMessage');
    self.errorMessage = $(contactFormWrapper).find('.errorMessage');
 
    self.HideSuccessAndError();

    $(self.contactFormSubmitButton).click(function (e) {
        if (self.IsContactFormValid()) {
            self.SubmitForm(e)
        } else {
            self.ShowError('The contact form is not valid');
        }
    });

    $(self.contactFormName).blur(function (e) {
        self.ValidateContactFormName();
    });

    $(self.contactFormEmail).blur(function (e) {
        self.ValidateContactFormEmail();
    });

    $(self.contactFormPhone).blur(function (e) {
        self.ValidateContactFormPhone();
    });

    $(self.contactFormMessage).blur(function (e) {
        self.ValidateContactFormMessage();
    });
}

Contact.prototype.SubmitForm = function (e) {
    var self = this;

    self.HideError();

    e.preventDefault();
    var name = self.contactFormName.val();
    var email = self.contactFormEmail.val();
    var phone = self.contactFormPhone.val();
    var message = self.contactFormMessage.val();

    $.ajax({
        type: "POST",
        url: self.contactFormSubmitUrl,
        dataType: "html",
        data: {
            'name': name,
            'email': email,
            'phone': phone,
            'message': message
        },
        success: function (result) {
            var resultModel = $.parseJSON(result);
            self.ShowSuccess(resultModel.message);
        },
        error: function (result) {

            var resultModel = $.parseJSON(result.responseText);
            self.ShowError(resultModel.message)
        }
    });
};

Contact.prototype.HideSuccessAndError = function () {
    var self = this;
    
    self.HideError();
    self.HideSuccess();
};

Contact.prototype.HideSuccess = function () {
    var self = this;

    self.successMessage.hide();
};

Contact.prototype.HideError = function () {
    var self = this;

    self.errorMessage.hide();
};

Contact.prototype.ShowSuccess = function (message) {
    var self = this;

    self.successMessage.text(message);
    self.successMessage.show();
};

Contact.prototype.ShowError = function (message) {
    var self = this;

    self.errorMessage.text('Error: ' + message);
    self.errorMessage.show();
};

Contact.prototype.ValidateContactFormName = function () {
    var self = this;

    self.IsContactFormNameValid = false;

    var contactFormNameValue = self.contactFormName.val();
    if (contactFormNameValue === 'undefined' || contactFormNameValue === '') {
        self.ShowError('Contact Name is empty');
    }

    self.IsContactFormNameValid = true;
};

Contact.prototype.ValidateContactFormEmail = function () {
    var self = this;

    self.IsContactFormEmailValid = false;

    var contactFormEmailValue = self.contactFormEmail.val();
    if (contactFormEmailValue === 'undefined' || contactFormEmailValue === '') {
        self.ShowError('Contact Email is empty');
    }

    var emailRegEx = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    if (!emailRegEx.test(contactFormEmailValue)) {
        self.ShowError('Contact Email is invalid');
    }

    self.IsContactFormEmailValid = true;
};

Contact.prototype.ValidateContactFormPhone = function () {
    var self = this;

    self.IsContactFormPhoneValid = false;

    var contactFormPhoneValue = self.contactFormPhone.val();
    if (contactFormPhoneValue != '' && !$.isNumeric(contactFormPhoneValue)) {
        self.ShowError('Contact Phone Number must be numeric');
    }

    self.IsContactFormPhoneValid = true;
};

Contact.prototype.ValidateContactFormMessage = function () {
    var self = this;

    self.IsContactFormMessageValid = false;

    var contactFormMessageValue = self.contactFormMessage.val();
    if (contactFormMessageValue === 'undefined' || contactFormMessageValue === '') {
        self.ShowError('Contact Message is empty');
    }

    if (contactFormMessageValue.length > 1000) {
        self.ShowError('Contact Message is over 1000 characters');
    }

    self.IsContactFormMessageValid = true;
};

Contact.prototype.IsContactFormValid = function() {
    var self = this;

    if (self.contactFormName && self.contactFormEmail
        && self.contactFormPhone && self.contactFormMessage) {
        return true;
    } else {
        return false;
    }
}