// customer-detail.js

const API_URL = 'https://localhost:7254/api/AngularCustomer';
let customerModal;

// Modal initialize
document.addEventListener('DOMContentLoaded', () => {
    console.log('DOM loaded');
    // Modal'ı static backdrop ile oluştur
    customerModal = new bootstrap.Modal(document.getElementById('showCustomerModal'), {
        backdrop: 'static',  // Modal dışına tıklayınca kapanmaz
        keyboard: false      // ESC tuşu ile kapanmaz
    });
});
// Show Customer


// Edit Customer (placeholder)
function editCustomer(id) {
    console.log('Edit customer:', id);
}

// Delete Customer (placeholder)
function deleteCustomer(id) {
    console.log('Delete customer:', id);
}