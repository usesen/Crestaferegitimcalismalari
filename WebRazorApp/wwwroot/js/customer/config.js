// Global değişkenler ve yapılandırmalar
//const API_CONFIG = {
//    baseUrl: 'https://localhost:7254',
//    endpoints: {
//        customer: '/api/AngularCustomer'
//    }
//};
//
//const UI_CONFIG = {
//    pageSize: 5,
//    toastr: {
//        closeButton: true,
//        progressBar: true,
//        positionClass: "toast-top-right",
//        timeOut: 3000
//    }
//};

// config.js

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
            currency: 'TRY'
        }
    },
    date: 'DD.MM.YYYY'
};