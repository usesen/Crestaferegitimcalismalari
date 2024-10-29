// Global değişkenler
const API_BASE_URL = 'https://localhost:7254';
const pageSize = 5;
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

// Sayfa yüklendiğinde
document.addEventListener('DOMContentLoaded', () => {
    // Modal'ları initialize et
    customerModal = new bootstrap.Modal(document.getElementById('showCustomerModal'));
    deleteConfirmModal = new bootstrap.Modal(document.getElementById('deleteConfirmModal'));

    // Toastr ayarları
    toastr.options = {
        "closeButton": true,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "timeOut": "3000"
    };

    // Event listener'ları ekle
    setupEventListeners();

    // İlk yükleme
    loadCustomers(1);
});

// Event Listener'ları kurma
function setupEventListeners() {
    // Arama butonu için event listener
    document.querySelector('button[type="submit"]').addEventListener('click', search);

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
}

// Arama fonksiyonu
function search() {
    searchParams = {
        name: document.getElementById('firstName')?.value?.trim() || '',
        company: document.getElementById('company')?.value?.trim() || '',
        country: document.getElementById('country')?.value?.trim() || ''
    };

    console.log('Search params:', searchParams);
    currentPage = 1;
    loadCustomers(1);
}

// Müşteri listesini yükleme
function loadCustomers(page = 1) {
    const tableBody = document.getElementById('customerTableBody');
    tableBody.innerHTML = '<tr><td colspan="7" class="text-center">Yükleniyor...</td></tr>';

    const params = new URLSearchParams({
        PageNumber: page,
        PageSize: pageSize,
        SortColumn: currentSort.column,
        SortDirection: currentSort.direction
    });

    if (searchParams.name) params.append('SearchName', searchParams.name);
    if (searchParams.company) params.append('SearchCompany', searchParams.company);
    if (searchParams.country) params.append('SearchCountry', searchParams.country);

    const url = `${API_BASE_URL}/api/AngularCustomer/getpaged?${params.toString()}`;

    fetch(url)
        .then(response => {
            if (!response.ok) {
                return response.json().then(err => {
                    throw new Error(JSON.stringify(err, null, 2));
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
            tableBody.innerHTML = `
                <tr>
                    <td colspan="7" class="text-center text-danger">
                        <i class="fas fa-exclamation-circle"></i> 
                        Veriler yüklenirken bir hata oluştu: ${error.message}
                    </td>
                </tr>
            `;
        });
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
        const response = await fetch(`${API_BASE_URL}/api/AngularCustomer/${customerIdToDelete}`, {
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
    try {
        const response = await fetch(`${API_BASE_URL}/api/AngularCustomer/${id}`);

        if (!response.ok) {
            throw new Error('Müşteri bilgileri alınamadı!');
        }

        const customer = await response.json();
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
                    <div class="form-control">${customer.phone || '-'}</div>
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

            <!-- Borç ve Alacak -->
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Borç</label>
                    <div class="form-control">₺${customer.debt?.toLocaleString('tr-TR', { minimumFractionDigits: 2 }) || '0,00'}</div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Alacak</label>
                    <div class="form-control">₺${customer.credit?.toLocaleString('tr-TR', { minimumFractionDigits: 2 }) || '0,00'}</div>
                </div>
            </div>

            <!-- Bakiye Borç ve Bakiye Alacak -->
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Bakiye Borç</label>
                    <div class="form-control">₺${customer.balanceDebt?.toLocaleString('tr-TR', { minimumFractionDigits: 2 }) || '0,00'}</div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label class="form-label custom-label">Bakiye Alacak</label>
                    <div class="form-control">₺${customer.balanceCredit?.toLocaleString('tr-TR', { minimumFractionDigits: 2 }) || '0,00'}</div>
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

        // Modalı göster
        customerModal.show();

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