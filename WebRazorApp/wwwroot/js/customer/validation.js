// Validation kuralları ve fonksiyonları
const PATTERNS = {
    stringField: new RegExp('^[a-zA-ZğüşıöçĞÜŞİÖÇ\\s]{2,50}$'),
    financialField: new RegExp('^\\d+(\\.\\d{1,2})?$'),
    email: new RegExp('^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,6}$'),
    phone: new RegExp('^[0-9]{10,11}$'),
    postalCode: new RegExp('^[0-9]{5,6}$')
};

// ... diğer validation kodları
function validateCustomerForm(customer) {
    const errors = [];

    // Ad ve Soyad kontrolü
    if (!PATTERNS.stringField.test(customer.firstName?.trim())) {
        errors.push('Ad alanı en az 2, en fazla 50 karakter olmalı ve sadece harf içermelidir.');
    }
    if (!PATTERNS.stringField.test(customer.lastName?.trim())) {
        errors.push('Soyad alanı en az 2, en fazla 50 karakter olmalı ve sadece harf içermelidir.');
    }

    // Email kontrolü
    if (!PATTERNS.email.test(customer.email?.trim())) {
        errors.push('Geçerli bir email adresi giriniz.');
    }

    // Telefon kontrolü (opsiyonel)
    if (customer.phone && !PATTERNS.phone.test(customer.phone.trim())) {
        errors.push('Telefon numarası 10-11 haneli olmalıdır.');
    }

    // Posta kodu kontrolü (opsiyonel)
    if (customer.postalCode && !PATTERNS.postalCode.test(customer.postalCode.trim())) {
        errors.push('Posta kodu 5-6 haneli olmalıdır.');
    }

    // Finansal alan kontrolleri
    if (customer.debt && !PATTERNS.financialField.test(customer.debt)) {
        errors.push('Borç alanı geçerli bir sayı olmalıdır.');
    }
    if (customer.credit && !PATTERNS.financialField.test(customer.credit)) {
        errors.push('Alacak alanı geçerli bir sayı olmalıdır.');
    }
    if (customer.balanceDebt && !PATTERNS.financialField.test(customer.balanceDebt)) {
        errors.push('Bakiye Borç alanı geçerli bir sayı olmalıdır.');
    }
    if (customer.balanceCredit && !PATTERNS.financialField.test(customer.balanceCredit)) {
        errors.push('Bakiye Alacak alanı geçerli bir sayı olmalıdır.');
    }

    return errors;
}

// validation.js

// Mevcut kodlar aynen kalacak ve altına eklenecek:

function validateField(field, value, pattern, errorMessage) {
    const errorDiv = field.nextElementSibling || document.createElement('div');
    errorDiv.className = 'invalid-feedback';

    if (!pattern.test(value.trim())) {
        field.classList.add('is-invalid');
        field.classList.remove('is-valid');
        errorDiv.textContent = errorMessage;
        if (!field.nextElementSibling) {
            field.parentNode.appendChild(errorDiv);
        }
        return false;
    } else {
        field.classList.remove('is-invalid');
        field.classList.add('is-valid');
        errorDiv.textContent = '';
        return true;
    }
}

function setupFieldValidation(field, pattern, errorMessage) {
    // Input girilirken kontrol
    field.addEventListener('input', (e) => {
        // Geçersiz karakterleri engelle
        if (!pattern.test(e.target.value)) {
            // Son geçerli değeri sakla
            if (!field.dataset.lastValidValue) {
                field.dataset.lastValidValue = '';
            }
            // Geçersiz karakteri engelle ve son geçerli değere geri dön
            e.target.value = field.dataset.lastValidValue;
            validateField(e.target, e.target.value, pattern, errorMessage);
        } else {
            // Geçerli değeri sakla
            field.dataset.lastValidValue = e.target.value;
            validateField(e.target, e.target.value, pattern, errorMessage);
        }
    });

    // Tab tuşu ile geçişi engelleme (opsiyonel)
    field.addEventListener('keydown', (e) => {
        if (e.key === 'Tab' && !pattern.test(e.target.value)) {
            e.preventDefault();
            showAlert('warning', errorMessage);
        }
    });
}
function setupFormValidation(formId) {
    const form = document.getElementById(formId);
    if (!form) return;

    const validationRules = [
        {
            field: 'firstName',
            pattern: PATTERNS.stringField,
            message: 'Ad alanı en az 2, en fazla 50 karakter olmalı ve sadece harf içermelidir.'
        },
        {
            field: 'lastName',
            pattern: PATTERNS.stringField,
            message: 'Soyad alanı en az 2, en fazla 50 karakter olmalı ve sadece harf içermelidir.'
        },
        {
            field: 'email',
            pattern: PATTERNS.email,
            message: 'Geçerli bir email adresi giriniz.'
        },
        {
            field: 'phone',
            pattern: PATTERNS.phone,
            message: 'Telefon numarası 10-11 haneli olmalıdır.'
        },
        {
            field: 'postalCode',
            pattern: PATTERNS.postalCode,
            message: 'Posta kodu 5-6 haneli olmalıdır.'
        }
    ];

    validationRules.forEach(rule => {
        const field = form.querySelector(`input[name="${rule.field}"]`);
        if (field) {
            setupFieldValidation(field, rule.pattern, rule.message);
        }
    });
}