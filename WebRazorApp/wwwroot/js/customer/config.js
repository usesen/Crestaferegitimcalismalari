// Global değişkenler ve yapılandırmalar

// API Yapılandırması
const API_CONFIG = {
    baseUrl: 'https://localhost:7254',
    endpoints: {
        customer: '/api/AngularCustomer'
    }
};

// UI Yapılandırması
const UI_CONFIG = {
    pageSize: 5,
    toastr: {
        closeButton: true,
        progressBar: true,
        positionClass: "toast-top-right",
        timeOut: 3000
    }
};

// Para birimi ve tarih formatı yapılandırması
const FORMAT_CONFIG = {
    currency: {
        locale: 'tr-TR',
        options: {
            style: 'currency',
            currency: 'TRY',
            minimumFractionDigits: 2,
            maximumFractionDigits: 2
        }
    },
    number: {
        style: 'decimal',
        minimumFractionDigits: 2,
        maximumFractionDigits: 2,
        useGrouping: true
    },
    date: 'DD.MM.YYYY'
};

// Formatlama fonksiyonu
function formatMoney(value) {
    return new Intl.NumberFormat('tr-TR', FORMAT_CONFIG.currency).format(value);
}

function formatNumber(value) {
    return new Intl.NumberFormat('tr-TR', FORMAT_CONFIG.number).format(value);
}

function formatPhone(phone) {
    if (!phone) return '';
    phone = phone.replace(/\D/g, ''); // Sadece rakamları al
    return phone.replace(/(\d{3})(\d{3})(\d{4})/, '($1) $2-$3');
}

 