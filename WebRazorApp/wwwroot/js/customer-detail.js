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
async function showCustomer(id) {
    try {
        // Modal elementlerini kontrol et
        const modalElement = document.getElementById('showCustomerModal');
        if (!modalElement) {
            console.error('Modal element not found!');
            return;
        }

        const modalBody = modalElement.querySelector('.modal-body');
        if (!modalBody) {
            console.error('Modal body not found!');
            return;
        }

        // Modal instance'ı kontrol et
        if (!customerModal) {
            customerModal = new bootstrap.Modal(modalElement);
        }

        // Loading göster
        modalBody.innerHTML = `
            <div class="d-flex justify-content-center py-5">
                <div class="spinner-border text-primary" role="status">
                    <span class="visually-hidden">Yükleniyor...</span>
                </div>
            </div>`;

        // Modal'ı göster
        customerModal.show();

        // API'den veri al
        const response = await fetch(`${API_URL}/${id}`);
        if (!response.ok) throw new Error('Müşteri bilgileri alınamadı');

        const customer = await response.json();
        console.log('Customer data:', customer);

        // İçeriği hazırla
        const content = `
            <div class="row g-3">
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-4">
                            <label class="form-label fw-bold">Ad Soyad:</label>
                        </div>
                        <div class="col-8">
                            <p class="form-control-plaintext">${customer.firstName} ${customer.lastName}</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-4">
                            <label class="form-label fw-bold">Email:</label>
                        </div>
                        <div class="col-8">
                            <p class="form-control-plaintext">${customer.email || '-'}</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-4">
                            <label class="form-label fw-bold">Telefon:</label>
                        </div>
                        <div class="col-8">
                            <p class="form-control-plaintext">${customer.phone || '-'}</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-4">
                            <label class="form-label fw-bold">Şirket:</label>
                        </div>
                        <div class="col-8">
                            <p class="form-control-plaintext">${customer.company || '-'}</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-4">
                            <label class="form-label fw-bold">Pozisyon:</label>
                        </div>
                        <div class="col-8">
                            <p class="form-control-plaintext">${customer.position || '-'}</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-4">
                            <label class="form-label fw-bold">Durum:</label>
                        </div>
                        <div class="col-8">
                            <p class="form-control-plaintext">
                                <span class="badge ${customer.isActive ? 'bg-success' : 'bg-danger'}">
                                    ${customer.isActive ? 'Aktif' : 'Pasif'}
                                </span>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-2">
                            <label class="form-label fw-bold">Adres:</label>
                        </div>
                        <div class="col-10">
                            <p class="form-control-plaintext">${customer.address || '-'}</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-4">
                            <label class="form-label fw-bold">Şehir:</label>
                        </div>
                        <div class="col-8">
                            <p class="form-control-plaintext">${customer.city || '-'}</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-4">
                            <label class="form-label fw-bold">Ülke:</label>
                        </div>
                        <div class="col-8">
                            <p class="form-control-plaintext">${customer.country || '-'}</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-4">
                            <label class="form-label fw-bold">Borç:</label>
                        </div>
                        <div class="col-8">
                            <p class="form-control-plaintext">₺${customer.debt?.toLocaleString('tr-TR', { minimumFractionDigits: 2 }) || '0,00'}</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-4">
                            <label class="form-label fw-bold">Alacak:</label>
                        </div>
                        <div class="col-8">
                            <p class="form-control-plaintext">₺${customer.credit?.toLocaleString('tr-TR', { minimumFractionDigits: 2 }) || '0,00'}</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-2">
                            <label class="form-label fw-bold">Notlar:</label>
                        </div>
                        <div class="col-10">
                            <p class="form-control-plaintext">${customer.notes || 'Not bulunmuyor'}</p>
                        </div>
                    </div>
                </div>
            </div>`;

        // İçeriği modal'a ekle
        console.log('Setting modal content...'); // Debug log
        modalBody.innerHTML = content;
        console.log('Modal content set successfully'); // Debug log

    } catch (error) {
        console.error('Error in showCustomer:', error);
        const modalBody = document.querySelector('#showCustomerModal .modal-body');
        if (modalBody) {
            modalBody.innerHTML = `
                <div class="alert alert-danger m-3">
                    <i class="fas fa-exclamation-circle me-2"></i> 
                    Hata: ${error.message}
                </div>`;
        }
    }
}

// Edit Customer (placeholder)
function editCustomer(id) {
    console.log('Edit customer:', id);
}

// Delete Customer (placeholder)
function deleteCustomer(id) {
    console.log('Delete customer:', id);
}