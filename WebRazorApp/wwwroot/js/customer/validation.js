// Validation kuralları ve fonksiyonları
const PATTERNS = {
    stringField: new RegExp('^[a-zA-ZğüşıöçĞÜŞİÖÇ\\s]{2,50}$'),
    financialField: new RegExp('^\\d+(\\.\\d{1,2})?$'),
    email: new RegExp('^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,6}$'),
    phone: new RegExp('^[0-9]{10,11}$'),
    postalCode: new RegExp('^[0-9]{5,6}$')
};

// ... diğer validation kodları