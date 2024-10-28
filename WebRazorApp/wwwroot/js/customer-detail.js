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
        // Değerleri kontrol edelim
        console.log('Müşteri Detayları:', {
            postalCode: customer.postalCode,
            type_postalCode: typeof customer.postalCode,
            balanceDebt: customer.balanceDebt,
            type_balanceDebt: typeof customer.balanceDebt,
            balanceCredit: customer.balanceCredit,
            type_balanceCredit: typeof customer.balanceCredit
        });

        // Test için değerleri direkt string olarak ekleyelim
        const testContent = `
            <div style="border: 1px solid red; padding: 10px; margin: 10px;">
                <p>Posta Kodu: ${customer.postalCode}</p>
                <p>Bakiye Borç: ${customer.balanceDebt}</p>
                <p>Bakiye Alacak: ${customer.balanceCredit}</p>
            </div>
        `;

        // İçeriği hazırla
        const content = `
    <div class="container-fluid p-0">
        <div class="row g-3">
            <!-- Kişisel Bilgiler -->
            <div class="col-md-6">
                <div class="row">
                    <div class="col-4">
                        <label class="form-label fw-bold">Ad:</label>
                    </div>
                    <div class="col-8">
                        <p class="form-control-plaintext">${customer.firstName}</p>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-4">
                        <label class="form-label fw-bold">Soyad:</label>
                    </div>
                    <div class="col-8">
                        <p class="form-control-plaintext">${customer.lastName}</p>
                    </div>
                </div>
            </div>

            <!-- İletişim Bilgileri -->
            <div class="col-md-6">
                <div class="row">
                    <div class="col-4">
                        <label class="form-label fw-bold">Email:</label>
                    </div>
                    <div class="col-8">
                        <p class="form-control-plaintext">${customer.email}</p>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-4">
                        <label class="form-label fw-bold">Telefon:</label>
                    </div>
                    <div class="col-8">
                        <p class="form-control-plaintext">${customer.phone}</p>
                    </div>
                </div>
            </div>

            <!-- İş Bilgileri -->
            <div class="col-md-6">
                <div class="row">
                    <div class="col-4">
                        <label class="form-label fw-bold">Şirket:</label>
                    </div>
                    <div class="col-8">
                        <p class="form-control-plaintext">${customer.company}</p>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-4">
                        <label class="form-label fw-bold">Pozisyon:</label>
                    </div>
                    <div class="col-8">
                        <p class="form-control-plaintext">${customer.position}</p>
                    </div>
                </div>
            </div>

            <!-- Adres Bilgileri -->
            <div class="col-12">
                <div class="row">
                    <div class="col-2">
                        <label class="form-label fw-bold">Adres:</label>
                    </div>
                    <div class="col-10">
                        <p class="form-control-plaintext">${customer.address}</p>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-4">
                        <label class="form-label fw-bold">Şehir:</label>
                    </div>
                    <div class="col-8">
                        <p class="form-control-plaintext">${customer.city}</p>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-4">
                        <label class="form-label fw-bold">Ülke:</label>
                    </div>
                    <div class="col-8">
                        <p class="form-control-plaintext">${customer.country}</p>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-4">
                        <label class="form-label fw-bold">Posta Kodu:</label>
                    </div>
                    <div class="col-8">
                        <p class="form-control-plaintext">${customer.postalCode}</p>
                    </div>
                </div>
            </div>

            <!-- Finansal Bilgiler -->
            <div class="col-md-6">
                <div class="row">
                    <div class="col-4">
                        <label class="form-label fw-bold">Borç:</label>
                    </div>
                    <div class="col-8">
                        <p class="form-control-plaintext">₺${customer.debt?.toLocaleString('tr-TR', { minimumFractionDigits: 2 })}</p>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-4">
                        <label class="form-label fw-bold">Alacak:</label>
                    </div>
                    <div class="col-8">
                        <p class="form-control-plaintext">₺${customer.credit?.toLocaleString('tr-TR', { minimumFractionDigits: 2 })}</p>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-4">
                        <label class="form-label fw-bold">Bakiye Borç:</label>
                    </div>
                    <div class="col-8">
                        <p class="form-control-plaintext">₺${customer.balanceDebt?.toLocaleString('tr-TR', { minimumFractionDigits: 2 })}</p>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-4">
                        <label class="form-label fw-bold">Bakiye Alacak:</label>
                    </div>
                    <div class="col-8">
                        <p class="form-control-plaintext">₺${customer.balanceCredit?.toLocaleString('tr-TR', { minimumFractionDigits: 2 })}</p>
                    </div>
                </div>
            </div>

            <!-- Notlar -->
            <div class="col-12">
                <div class="row">
                    <div class="col-2">
                        <label class="form-label fw-bold">Notlar:</label>
                    </div>
                    <div class="col-10">
                        <p class="form-control-plaintext">${customer.notes || 'Not bulunmuyor'}</p>
                    </div>
                </div>
            </div>
        </div>
    </div>`;

        // İçeriği modal'a ekle
        console.log('Setting modal content...'); // Debug log
        const modalBody = document.querySelector('#showCustomerModal .modal-body');
        modalBody.innerHTML = testContent + content;
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