// Global değişkenler


let currentPage = 1;
let currentSort = {
    column: 'id',
    direction: 'asc'
};
let searchParams = {
    name: '',
    company: '',
    country: ''
};
let customerModal = null;
let deleteConfirmModal = null;
let customerIdToDelete = null;

// Arama fonksiyonu
function search(e) {
    if (e) e.preventDefault();

    searchParams = {
        name: document.getElementById('firstName')?.value?.trim() || '',
        company: document.getElementById('company')?.value?.trim() || '',
        country: document.getElementById('country')?.value?.trim() || ''
    };

    console.log('Search params:', searchParams);
    currentPage = 1;
    loadCustomers(1);
}

// Event Listener'ları kurma
function setupEventListeners() {
    // Arama butonu için event listener
    const searchButton = document.querySelector('button[type="submit"]');
    if (searchButton) {
        searchButton.addEventListener('click', search);
    }

    // Input'lara Enter event'i ekle
    document.querySelectorAll('.form-control').forEach(input => {
        input.addEventListener('keypress', function (e) {
            if (e.key === 'Enter') {
                search();
            }
        });
    });

    // Silme onay butonu için event listener
    const confirmDeleteBtn = document.getElementById('confirmDeleteButton');
    if (confirmDeleteBtn) {
        confirmDeleteBtn.addEventListener('click', confirmDelete);
    }

    // Arama form elemanları için event listener'lar
    const firstNameInput = document.getElementById('firstName');
    const companyInput = document.getElementById('company');
    const countryInput = document.getElementById('country');

    if (firstNameInput) firstNameInput.addEventListener('input', search);
    if (companyInput) companyInput.addEventListener('input', search);
    if (countryInput) countryInput.addEventListener('input', search);
}

// Tek bir DOMContentLoaded event listener
document.addEventListener('DOMContentLoaded', () => {
    console.log('DOM yüklendi');

    // Modal'ları initialize et
    customerModal = new bootstrap.Modal(document.getElementById('showCustomerModal'));
    deleteConfirmModal = new bootstrap.Modal(document.getElementById('deleteConfirmModal'));

    // Event listener'ları ekle
    setupEventListeners();

    // İlk yükleme
    loadCustomers(1);
    console.log('İlk yükleme yapıldı');
});

 

// Müşteri listesini yükleme
function loadCustomers(page = 1) {
    showLoading();
    const tableBody = document.getElementById('customerTableBody');
    tableBody.innerHTML = '<tr><td colspan="7" class="text-center">Yükleniyor...</td></tr>';

    const params = new URLSearchParams({
        PageNumber: page,
        PageSize: UI_CONFIG.pageSize,
        SortColumn: currentSort.column,
        SortDirection: currentSort.direction
    });

    if (searchParams.name) params.append('SearchName', searchParams.name);
    if (searchParams.company) params.append('SearchCompany', searchParams.company);
    if (searchParams.country) params.append('SearchCountry', searchParams.country);

    const url = `${API_CONFIG.baseUrl}${API_CONFIG.endpoints.customer}/getpaged?${params.toString()}`;
    try {
        fetch(url)
            .then(response => {
                if (!response.ok) {
                    return response.json().then(err => {
                        throw new Error(err.message || 'Veriler yüklenirken bir hata oluştu');
                    });
                }
                return response.json();
            })
            .then(data => {
                displayCustomers(data);
                updatePagination(data);
                updateSortIcons();
            })
            .catch(error => {
                console.error('Error:', error);
                showAlert('error', error.message); // Toastr ile hata mesajı
                tableBody.innerHTML = `
                <tr>
                    <td colspan="7" class="text-center text-danger">
                        <i class="fas fa-exclamation-circle"></i> 
                        Veriler yüklenirken bir hata oluştu
                    </td>
                </tr>
            `;
            });
    } catch (error) {
        console.error('Error:', error);
        showAlert('error', 'Veriler yüklenirken bir hata oluştu!');
    } finally {
        hideLoading();
    }
   
}
// Müşteri listesini görüntüleme
function displayCustomers(data) {
    const tableBody = document.getElementById('customerTableBody');
    tableBody.innerHTML = '';

    data.items.forEach(customer => {
        const row = document.createElement('tr');
        row.innerHTML = `
            <td>${customer.id}</td>
            <td>${customer.firstName} ${customer.lastName}</td>
            <td>${customer.email}</td>
            <td>${customer.company}</td>
            <td>${customer.city}</td>
            <td>${customer.country}</td>
            <td>${formatMoney(customer.debt)}</td>
            <td>${formatMoney(customer.credit)}</td>
            <td>${formatMoney(customer.balanceDebt)}</td>
            <td>${formatMoney(customer.balanceCredit)}</td>
            <td class="text-center">
                <button class="btn btn-info btn-sm" onclick="showCustomer(${customer.id})">
                    <i class="fas fa-eye"></i>
                </button>
                <button class="btn btn-warning btn-sm" onclick="editCustomer(${customer.id})">
                    <i class="fas fa-edit"></i>
                </button>
                <button class="btn btn-danger btn-sm" onclick="deleteCustomer(${customer.id})">
                    <i class="fas fa-times"></i>
                </button>
            </td>
        `;
        tableBody.appendChild(row);
    });
}

// Sayfalama güncelleme
function updatePagination(data) {
    const pagination = document.querySelector('.pagination');
    if (!pagination) return;

    pagination.innerHTML = '';

    // Önceki sayfa
    const prevLi = document.createElement('li');
    prevLi.className = `page-item ${data.currentPage === 1 ? 'disabled' : ''}`;
    prevLi.innerHTML = `
        <a class="page-link" href="#" onclick="changePage(${data.currentPage - 1}); return false;">
            Önceki
        </a>
    `;
    pagination.appendChild(prevLi);

    // Sayfa numaraları
    for (let i = 1; i <= data.totalPages; i++) {
        const li = document.createElement('li');
        li.className = `page-item ${data.currentPage === i ? 'active' : ''}`;
        li.innerHTML = `
            <a class="page-link" href="#" onclick="changePage(${i}); return false;">
                ${i}
            </a>
        `;
        pagination.appendChild(li);
    }

    // Sonraki sayfa
    const nextLi = document.createElement('li');
    nextLi.className = `page-item ${data.currentPage === data.totalPages ? 'disabled' : ''}`;
    nextLi.innerHTML = `
        <a class="page-link" href="#" onclick="changePage(${data.currentPage + 1}); return false;">
            Sonraki
        </a>
    `;
    pagination.appendChild(nextLi);
}

// Sayfa değiştirme
function changePage(page) {
    if (page < 1) return;
    currentPage = page;
    loadCustomers(page);
}

// Sıralama
function sortBy(column) {
    if (currentSort.column === column) {
        currentSort.direction = currentSort.direction === 'asc' ? 'desc' : 'asc';
    } else {
        currentSort.column = column;
        currentSort.direction = 'asc';
    }

    updateSortIcons();
    loadCustomers(currentPage);
}

// Sıralama ikonlarını güncelleme
function updateSortIcons() {
    document.querySelectorAll('.fa-sort, .fa-sort-up, .fa-sort-down').forEach(icon => {
        icon.className = 'fas fa-sort';
    });

    const activeIcon = document.getElementById(`sort-${currentSort.column}`);
    if (activeIcon) {
        activeIcon.className = `fas fa-sort-${currentSort.direction === 'asc' ? 'up' : 'down'}`;
    }
}

// Alert gösterme
function showAlert(type, message) {
    toastr.options = UI_CONFIG.toastr;
    switch (type) {
        case 'success':
            toastr.success(message);
            break;
        case 'error':
            toastr.error(message);
            break;
        case 'warning':
            toastr.warning(message);
            break;
        case 'info':
            toastr.info(message);
            break;
    }
}

// Silme işlemleri
function deleteCustomer(id) {
    customerIdToDelete = id;
    deleteConfirmModal.show();
}

async function confirmDelete() {
    try {
        const response = await fetch(`${API_CONFIG.baseUrl}${API_CONFIG.endpoints.customer}/${customerIdToDelete}`, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        });

        if (!response.ok) {
            switch (response.status) {
                case 404:
                    showAlert('error', 'Kayıt bulunamadı! 🔍');
                    break;
                case 400:
                    showAlert('error', 'Geçersiz istek! ⚠️');
                    break;
                case 401:
                    showAlert('error', 'Yetkiniz yok! 🔒');
                    break;
                case 403:
                    showAlert('error', 'Bu işlem için izniniz yok! 🚫');
                    break;
                case 500:
                    showAlert('error', 'Sunucu hatası! Lütfen tekrar deneyin. ⚡');
                    break;
                default:
                    showAlert('error', 'Silme işlemi başarısız oldu! ❌');
            }
            deleteConfirmModal.hide();
            return;
        }

        deleteConfirmModal.hide();
        showAlert('success', 'Kayıt başarıyla silindi! 👍');
        loadCustomers(currentPage);

    } catch (error) {
        console.error('Error:', error);
        showAlert('error', 'Beklenmeyen bir hata oluştu! 🔥');
        deleteConfirmModal.hide();
    }
}

async function showCustomer(id) {
    showLoading();
    try {
        const response = await fetch(`${API_CONFIG.baseUrl}${API_CONFIG.endpoints.customer}/${id}`);

        if (!response.ok) {
            throw new Error('Müşteri bilgileri alınamadı!');
        }

        const customer = await response.json();
        console.log('Customer data:', customer);

        const content = `
    <div class="container-fluid p-0">
        <div class="row g-3">
            <!-- Kişisel Bilgiler -->
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Ad</label>
                    <div class="form-control">${customer.firstName || '-'}</div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Soyad</label>
                    <div class="form-control">${customer.lastName || '-'}</div>
                </div>
            </div>

            <!-- İletişim Bilgileri -->
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Email</label>
                    <div class="form-control">${customer.email || '-'}</div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Telefon</label>
                     <div class="form-control">${formatPhone(customer.phone)}</div>
                </div>
            </div>

            <!-- İş Bilgileri -->
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Şirket</label>
                    <div class="form-control">${customer.company || '-'}</div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Pozisyon</label>
                    <div class="form-control">${customer.position || '-'}</div>
                </div>
            </div>

            <!-- Adres Bilgileri -->
            <div class="col-12">
                <div class="form-group">
                    <label class="form-label custom-label">Adres</label>
                    <div class="form-control">${customer.address || '-'}</div>
                </div>
            </div>

            <!-- Şehir, Ülke, Posta Kodu -->
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-label custom-label">Şehir</label>
                    <div class="form-control">${customer.city || '-'}</div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-label custom-label">Ülke</label>
                    <div class="form-control">${customer.country || '-'}</div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-label custom-label">Posta Kodu</label>
                    <div class="form-control">${customer.postalCode || '-'}</div>
                </div>
            </div>

            <!-- Finansal Bilgiler -->
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="form-label custom-label">Borç</label>
                        <div class="form-control">${formatMoney(customer.debt)}</div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="form-label custom-label">Alacak</label>
                        <div class="form-control">${formatMoney(customer.credit)}</div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="form-label custom-label">Bakiye Borç</label>
                        <div class="form-control">${formatMoney(customer.balanceDebt)}</div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="form-label custom-label">Bakiye Alacak</label>
                        <div class="form-control">${formatMoney(customer.balanceCredit)}</div>
                    </div>
                </div>          

            <!-- Notlar -->
            <div class="col-12">
                <div class="form-group">
                    <label class="form-label custom-label">Notlar</label>
                    <div class="form-control">${customer.notes || 'Not bulunmuyor'}</div>
                </div>
            </div>
        </div>
    </div>`;

        // Modal başlığını güncelle
        const modalTitle = document.querySelector('#showCustomerModal .modal-title');
        modalTitle.innerHTML = `<i class="fas fa-user me-2"></i>Müşteri Detayları (#${customer.id})`;

        // İçeriği modal'a ekle
        const modalBody = document.querySelector('#showCustomerModal .modal-body');
        modalBody.innerHTML = content;

        // Modal'ı göster
        customerModal.show();

    } catch (error) {
        console.error('Error in showCustomer:', error);
        showAlert('error', error.message);
    } finally {
        hideLoading();
    }
}
async function editCustomer(id) {
    showLoading();
    try {
        const response = await fetch(`${API_CONFIG.baseUrl}${API_CONFIG.endpoints.customer}/${id}`);

        if (!response.ok) {
            throw new Error('Müşteri bilgileri alınamadı!');
        }

        const customer = await response.json();

        const content = `
    <div class="container-fluid p-0">
        <form id="editCustomerForm" class="row g-3">
            <!-- Kişisel Bilgiler -->
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Ad</label>
                    <input type="text" class="form-control" name="firstName" value="${customer.firstName || ''}" required>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Soyad</label>
                    <input type="text" class="form-control" name="lastName" value="${customer.lastName || ''}" required>
                </div>
            </div>

            <!-- İletişim Bilgileri -->
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Email</label>
                    <input type="email" class="form-control" name="email" value="${customer.email || ''}" required>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Telefon</label>
                    <input type="tel" class="form-control" name="phone" value="${formatPhone(customer.phone)}">
                </div>
            </div>

            <!-- İş Bilgileri -->
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Şirket</label>
                    <input type="text" class="form-control" name="company" value="${customer.company || ''}">
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Pozisyon</label>
                    <input type="text" class="form-control" name="position" value="${customer.position || ''}">
                </div>
            </div>

            <!-- Adres Bilgileri -->
            <div class="col-12">
                <div class="form-group">
                    <label class="form-label custom-label">Adres</label>
                    <textarea class="form-control" name="address" rows="2">${customer.address || ''}</textarea>
                </div>
            </div>

            <!-- Şehir, Ülke, Posta Kodu -->
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-label custom-label">Şehir</label>
                    <input type="text" class="form-control" name="city" value="${customer.city || ''}">
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-label custom-label">Ülke</label>
                    <input type="text" class="form-control" name="country" value="${customer.country || ''}">
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-label custom-label">Posta Kodu</label>
                    <input type="text" class="form-control" name="postalCode" value="${customer.postalCode || ''}">
                </div>
            </div>

             <!-- Finansal Bilgiler -->
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Borç</label>
                    <input type="number" step="0.01" class="form-control" name="debt" value="${customer.debt || 0}">
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Alacak</label>
                    <input type="number" step="0.01" class="form-control" name="credit" value="${customer.credit || 0}">
                </div>
            </div>

            <!-- Bakiye Borç ve Bakiye Alacak -->
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Bakiye Borç</label>
                    <input type="number" step="0.01" class="form-control" name="balanceDebt" value="${customer.balanceDebt || 0}">
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Bakiye Alacak</label>
                    <input type="number" step="0.01" class="form-control" name="balanceCredit" value="${customer.balanceCredit || 0}">
                </div>
            </div>

            <!-- Notlar -->
            <div class="col-12">
                <div class="form-group">
                    <label class="form-label custom-label">Notlar</label>
                    <textarea class="form-control" name="notes" rows="3">${customer.notes || ''}</textarea>
                </div>
            </div>

            <input type="hidden" name="id" value="${customer.id}">
        </form>
    </div>`;

        // Modal başlığını güncelle
        const modalTitle = document.querySelector('#showCustomerModal .modal-title');
        modalTitle.innerHTML = `<i class="fas fa-edit me-2"></i>Müşteri Düzenle (#${customer.id})`;

        // Modal footer'ı güncelle
        const modalFooter = document.querySelector('#showCustomerModal .modal-footer');
        modalFooter.innerHTML = `
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">
                <i class="fas fa-times me-2"></i>İptal
            </button>
            <button type="button" class="btn btn-primary" onclick="saveCustomer()">
                <i class="fas fa-save me-2"></i>Kaydet
            </button>
        `;

        // İçeriği modal'a ekle
        const modalBody = document.querySelector('#showCustomerModal .modal-body');
        modalBody.innerHTML = content;
        // Form validasyonunu aktif et
        setupFormValidation('editCustomerForm');
        // Modalı göster
        customerModal.show();

    } catch (error) {
        console.error('Error:', error);
        showAlert('error', 'Müşteri bilgileri yüklenirken bir hata oluştu!');
    } finally {
        hideLoading();
    }
}
async function saveCustomer() {
    showLoading();
    try {
        const form = document.getElementById('editCustomerForm');
        const formData = new FormData(form);
        const customer = Object.fromEntries(formData.entries());

        // HTML5 form validasyonu
        if (!form.checkValidity()) {
            form.reportValidity();
            return;
        }
        // Telefon numarasını temizle
        customer.phone = cleanPhoneNumber(customer.phone);

        // Sayısal değerleri dönüştür
        customer.debt = parseFloat(customer.debt) || 0;
        customer.credit = parseFloat(customer.credit) || 0;
        customer.balanceDebt = parseFloat(customer.balanceDebt) || 0;
        customer.balanceCredit = parseFloat(customer.balanceCredit) || 0;

        // Özel validasyon kuralları
        const errors = validateCustomerForm(customer);
        if (errors.length > 0) {
            errors.forEach(error => showAlert('warning', error));
            return;
        }

        const response = await fetch(`${API_CONFIG.baseUrl}${API_CONFIG.endpoints.customer}/${customer.id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(customer)
        });


        if (!response.ok) {
            throw new Error('Müşteri güncellenirken bir hata oluştu!');
        }

        showAlert('success', 'Müşteri başarıyla güncellendi!');
        customerModal.hide();
        loadCustomers(currentPage);

    } catch (error) {
        console.error('Error:', error);
        showAlert('error', error.message);
    } finally {
        hideLoading();
    }
}


function createCustomer() {

    // Modal başlığını güncelle
    const modalTitle = document.querySelector('#showCustomerModal .modal-title');
    if (modalTitle) {
        modalTitle.innerHTML = `<i class="fas fa-plus-circle me-2"></i>Yeni Müşteri`;
    }

    // Modal footer'ı güncelle
    const modalFooter = document.querySelector('#showCustomerModal .modal-footer');
    if (modalFooter) {
        modalFooter.innerHTML = `
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">
                <i class="fas fa-times me-2"></i>İptal
            </button>
            <button type="button" class="btn btn-success" onclick="saveNewCustomer()">
                <i class="fas fa-save me-2"></i>Kaydet
            </button>
        `;
    }

    // İçeriği modal'a ekle
    const modalBody = document.querySelector('#showCustomerModal .modal-body');
    if (modalBody) {
        modalBody.innerHTML = createCustomerFormTemplate(); // Form şablonunu ayrı bir fonksiyona taşıyalım
    }

    // Form validasyonunu aktif et
    setupFormValidation('createCustomerForm');

    // Temizle butonunu ekle
    addResetButton('createCustomerForm');

    // Modalı göster
    customerModal.show();
}

// Form şablonunu ayrı bir fonksiyon olarak tanımlayalım
function createCustomerFormTemplate() {
    return `
      <div class="container-fluid p-0">
        <form id="createCustomerForm" class="row g-3">
            <!-- Kişisel Bilgiler -->
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Ad</label>
                    <input type="text" class="form-control" name="firstName" required>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Soyad</label>
                    <input type="text" class="form-control" name="lastName" required>
                </div>
            </div>

            <!-- İletişim Bilgileri -->
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Email</label>
                    <input type="email" class="form-control" name="email" required>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Telefon</label>
                    <input type="tel" class="form-control" name="phone">
                </div>
            </div>

            <!-- İş Bilgileri -->
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Şirket</label>
                    <input type="text" class="form-control" name="company">
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Pozisyon</label>
                    <input type="text" class="form-control" name="position">
                </div>
            </div>

            <!-- Adres Bilgileri -->
            <div class="col-12">
                <div class="form-group">
                    <label class="form-label custom-label">Adres</label>
                    <textarea class="form-control" name="address" rows="2"></textarea>
                </div>
            </div>

            <!-- Şehir, Ülke, Posta Kodu -->
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-label custom-label">Şehir</label>
                    <input type="text" class="form-control" name="city">
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-label custom-label">Ülke</label>
                    <input type="text" class="form-control" name="country">
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-label custom-label">Posta Kodu</label>
                    <input type="text" class="form-control" name="postalCode">
                </div>
            </div>

            <!-- Finansal Bilgiler -->
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Borç</label>
                    <input type="number" step="0.01" class="form-control" name="debt" value="0">
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Alacak</label>
                    <input type="number" step="0.01" class="form-control" name="credit" value="0">
                </div>
            </div>

            <!-- Bakiye Borç ve Bakiye Alacak -->
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Bakiye Borç</label>
                    <input type="number" step="0.01" class="form-control" name="balanceDebt" value="0">
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Bakiye Alacak</label>
                    <input type="number" step="0.01" class="form-control" name="balanceCredit" value="0">
                </div>
            </div>

            <!-- Notlar -->
            <div class="col-12">
                <div class="form-group">
                    <label class="form-label custom-label">Notlar</label>
                    <textarea class="form-control" name="notes" rows="3"></textarea>
                </div>
            </div>
        </form>
    </div>
  `;
}

// Yardımcı fonksiyonlar
function cleanPhoneNumber(phone) {
    // Telefon numarasından tüm özel karakterleri ve boşlukları temizle
    return phone ? phone.replace(/[^\d]/g, '') : '';
}
 

async function saveNewCustomer() {
    showLoading();
    try {
        const form = document.getElementById('createCustomerForm');

        // HTML5 form validasyonu
        if (!form.checkValidity()) {
            form.reportValidity();
            return;
        }

        const formData = new FormData(form);
        const customer = Object.fromEntries(formData.entries());

        // Telefon numarasını temizle
        customer.phone = cleanPhoneNumber(customer.phone);

        // Sayısal değerleri dönüştür
        customer.debt = parseFloat(customer.debt) || 0;
        customer.credit = parseFloat(customer.credit) || 0;
        customer.balanceDebt = parseFloat(customer.balanceDebt) || 0;
        customer.balanceCredit = parseFloat(customer.balanceCredit) || 0;

        // Özel validasyon kuralları
        const errors = validateCustomerForm(customer);
        if (errors.length > 0) {
            errors.forEach(error => showAlert('warning', error));
            return;
        }

        const response = await fetch(`${API_CONFIG.baseUrl}${API_CONFIG.endpoints.customer}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(customer)
        });

        if (!response.ok) {
            throw new Error('Müşteri eklenirken bir hata oluştu!');
        }

        showAlert('success', 'Müşteri başarıyla eklendi!');
        customerModal.hide();
        loadCustomers(currentPage);

    } catch (error) {
        console.error('Error:', error);
        showAlert('error', error.message);
    }
    finally {
        hideLoading();
    }
}

// main.js'e ekleyin
function showLoading() {
    const loadingHtml = `
        <div class="loading-spinner">
            <div class="spinner-border text-primary" role="status">
                <span class="visually-hidden">Yükleniyor...</span>
            </div>
        </div>`;
    document.body.insertAdjacentHTML('beforeend', loadingHtml);
}

function hideLoading() {
    const spinner = document.querySelector('.loading-spinner');
    if (spinner) spinner.remove();
}
// main.js'e ekleyelim
function addResetButton(formId) {
    const form = document.getElementById(formId);
    const resetBtn = document.createElement('button');
    resetBtn.type = 'button';
    resetBtn.className = 'btn btn-secondary me-2';
    resetBtn.innerHTML = '<i class="fas fa-undo me-1"></i> Temizle';
    resetBtn.onclick = () => {
        form.reset();
        // Validasyon işaretlerini temizle
        form.querySelectorAll('.is-valid, .is-invalid').forEach(el => {
            el.classList.remove('is-valid', 'is-invalid');
        });
        // Hata mesajlarını temizle
        form.querySelectorAll('.invalid-feedback').forEach(el => {
            el.textContent = '';
        });
    };

    // Butonu kaydet butonunun yanına ekle
    const submitBtn = form.querySelector('button[type="submit"]');
    submitBtn.parentNode.insertBefore(resetBtn, submitBtn);
}



// Reset butonu ekleme fonksiyonu
function addResetButton(formId) {
    const form = document.getElementById(formId);
    if (!form) return; // Form yoksa çık

    const resetBtn = document.createElement('button');
    resetBtn.type = 'button';
    resetBtn.className = 'btn btn-secondary me-2';
    resetBtn.innerHTML = '<i class="fas fa-undo me-1"></i> Temizle';
    resetBtn.onclick = () => {
        form.reset();
        // Validasyon işaretlerini temizle
        form.querySelectorAll('.is-valid, .is-invalid').forEach(el => {
            el.classList.remove('is-valid', 'is-invalid');
        });
        // Hata mesajlarını temizle
        form.querySelectorAll('.invalid-feedback').forEach(el => {
            el.textContent = '';
        });
    };

    // Modal footer'a ekle
    const modalFooter = document.querySelector('#showCustomerModal .modal-footer');
    if (modalFooter) {
        modalFooter.insertBefore(resetBtn, modalFooter.firstChild);
    }
}

// CSV Export fonksiyonu
async function exportToCSV() {
    try {
        showLoading();

        // Mevcut arama parametrelerini kullan
        const params = new URLSearchParams({
            PageNumber: 1,
            PageSize: 1000,
            SortColumn: currentSort.column,
            SortDirection: currentSort.direction
        });

        // Arama parametrelerini ekle
        if (searchParams.name) params.append('SearchName', searchParams.name);
        if (searchParams.company) params.append('SearchCompany', searchParams.company);
        if (searchParams.country) params.append('SearchCountry', searchParams.country);

        // Filtrelenmiş datayı getir
        const response = await fetch(`${API_CONFIG.baseUrl}${API_CONFIG.endpoints.customer}/getpaged?${params.toString()}`, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        });

        if (!response.ok) throw new Error('Veriler alınamadı!');
        const data = await response.json();

        // Eğer data boşsa uyarı ver
        if (!data.items || data.items.length === 0) {
            showAlert('warning', 'Aktarılacak kayıt bulunamadı!');
            return;
        }

        // ... geri kalan export kodu aynı ...
        const headers = [
            'Ad',
            'Soyad',
            'Email',
            'Telefon',
            'Şirket',
            'Pozisyon',
            'Adres',
            'Şehir',
            'Ülke',
            'Posta Kodu',
            'Borç',
            'Alacak',
            'Bakiye Borç',
            'Bakiye Alacak',
            'Notlar'
        ];

        const csvRows = [
            headers.join(';'),
            ...data.items.map(customer => [
                customer.firstName || '',
                customer.lastName || '',
                customer.email || '',
                formatPhone(customer.phone) || '',
                customer.company || '',
                customer.position || '',
                customer.address || '',
                customer.city || '',
                customer.country || '',
                customer.postalCode || '',
                formatMoneyForCSV(customer.debt),
                formatMoneyForCSV(customer.credit),
                formatMoneyForCSV(customer.balanceDebt),
                formatMoneyForCSV(customer.balanceCredit),
                customer.notes || ''
            ].join(';'))
        ];

        const csvContent = '\ufeff' + csvRows.join('\n');

        // Tarih ve saat ile dosya adı oluştur
        const now = new Date();
        const dateStr = now.toISOString()
            .replace(/T/, '_')
            .replace(/\..+/, '')
            .replace(/:/g, '-');

        // Filtreleme varsa dosya adına ekle
        let fileName = `Musteriler_${dateStr}`;
        if (searchParams.name || searchParams.company || searchParams.country) {
            fileName += '_Filtered';
        }
        fileName += '.csv';

        const blob = new Blob([csvContent], { type: 'text/csv;charset=utf-8;' });
        const link = document.createElement('a');
        link.href = URL.createObjectURL(blob);
        link.download = fileName;
        link.style.display = 'none';

        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);

        showAlert('success', 'CSV dosyası başarıyla indirildi! 📥');

    } catch (error) {
        console.error('Export error:', error);
        showAlert('error', 'CSV dosyası oluşturulurken bir hata oluştu! ❌');
    } finally {
        hideLoading();
    }
}
// Para formatı için yardımcı fonksiyon
function formatMoneyForCSV(value) {
    if (!value) return '0';

    // Sayıyı düzgün formata çevir (1234.56 -> 1.234,56)
    return Number(value)
        .toLocaleString('tr-TR', {
            minimumFractionDigits: 2,
            maximumFractionDigits: 2
        })
        .replace(/\./g, '*')  // Binlik ayracını geçici olarak yıldız yap
        .replace(/,/g, '.')   // Ondalık ayracını nokta yap
        .replace(/\*/g, ','); // Binlik ayracını virgül yap
}