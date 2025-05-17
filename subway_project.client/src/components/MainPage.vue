<script setup>
  import { ref, reactive, watch, onMounted } from "vue";
  import { useOrderStore } from "@/stores/useOrderStore";
  import { useSubStore } from "@/stores/SubStore";

  const orderStore = useOrderStore();
  const subStore = useSubStore();

  onMounted(() => {
    getProducts();
  });

  const baseUrl = "https://localhost:7193";

  const props = defineProps({
    selectedSubCategory: Object,
    cartLimits: Object
  });

  const products = reactive([]);
  const filteredProducts = ref([]);
  let showProducts = ref(false);

  const getProducts = async () => {
    const response = await fetch(baseUrl + "/api/products");
    const data = await response.json();
    products.value = data;

    showProducts.value = !showProducts.value;
  };

  watch(
    () => props.selectedSubCategory,
    (newSubCat) => {
      if (!newSubCat) {
        filteredProducts.value = [];
        return;
      }

      filteredProducts.value = products.value.filter(
        (p) => p.subCategoryId === newSubCat.id
      );
    },
    { immediate: true }
  );

  function AddToCart(emittedProduct) {
    orderStore.addProduct(emittedProduct);
  }

  const addToSub = (product) => {
    subStore.addProduct(product);
  };

  const isAddToSubDisabled = (subCatId) => {
    if (!props.cartLimits || !subStore.sub.products) {
      return false; // No limits or products in subStore, so not disabled
    }

    if (props.selectedSubCategory.categoryId === 2 && props.selectedSubCategory.id !== 1) { //if category is "Sub", and subcategory is not "Bread"
      const subHasBread = subStore.sub.products.findIndex(product => product.subCategoryId === 1) !== -1; //check if there is bread in the sub
      if (subHasBread) { //if there is bread in the sub
        const productCount = subStore.sub.products.filter(product => product.subCategoryId === subCatId).length; //check number of items of the subcategory in the sub
        return productCount >= props.cartLimits[subCatId]; //return true/false depending on if the limit is reached
      }
      return true; //if there is no bread in the sub, return true to disable the button
    }

    //for any other subcategories check number of items of the subcategory in the cart, and return true/false depending on if the limit is reached
    const productCount = subStore.sub.products.filter(product => product.subCategoryId === subCatId).length;
    return productCount >= props.cartLimits[subCatId];
  };
</script>

<template>

  <div v-if="showProducts" class="products-container">
    <div v-for="p in filteredProducts" :key="p.id" :id="`product-` + p.id" class="product">
      <img class="image" :src="p.imageUrl" alt="Product Image">
      <h1>{{ p.name }}</h1>
      <p>Price: {{ p.price }}kr</p>
      <p>Kcal: {{ p.calories }}</p>
      <button v-if="p.categoryId === 2" class="button" @click="addToSub(p)" :disabled="isAddToSubDisabled(p.subCategoryId)">
        <!-- Visual Studio says "'isAddToSubDisabled(p.subCategoryId)' is not a valid value of attribute 'disabled'",
        but the functionality works as intended (i.e. the button is disabled if a certain amount of a product is in "items"). -->
        ADD TO SUB!
      </button>
      <button v-else class="button" @click="AddToCart(p)">
        EAT ME!
      </button>
    </div>
  </div>

</template>

<style>
  h1 {
    font-size: 1.2rem;
    margin: 12px 0 6px;
    text-align: center;
  }

  .image {
    width: 100%;
    height: 300px;
    object-fit: cover;
  }

  .products-container {
    margin: 20px;
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
  }

  .product {
    background-color: #ffffff;
    border-radius: 16px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    align-items: center;
    flex: 1 1 22vw;
    max-width: 22vw;
    padding: 16px;
    margin: 12px;
    transition: transform 0.2s ease, box-shadow 0.2s ease;
    cursor: pointer;
  }

    .product:hover {
      transform: translateY(-5px);
      box-shadow: 0 8px 16px rgba(0, 0, 0, 0.15);
    }

    .product .button {
      background-color: #38a169;
      color: white;
      border: none;
      padding: 8px 16px;
      border-radius: 8px;
      margin-top: 10px;
      transition: background-color 0.2s ease;
    }

      .product .button:hover {
        background-color: #2f855a;
      }

      .product .button:disabled {
        background-color: #e2e8f0;
        color: #a0aec0;
        cursor: not-allowed;
      }
</style>
