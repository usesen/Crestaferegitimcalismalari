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