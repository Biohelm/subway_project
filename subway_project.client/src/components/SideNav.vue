<script setup>
  import { ref, onBeforeMount } from "vue";
  import router from "@/router";

  const baseUrl = "https://localhost:7193";
  const categories = ref([]);
  const subCategories = ref([]);
  const subsToShow = ref([]);
  const emit = defineEmits(["subcategorySelected"]);

  const handleSubCategoryClick = (subCategory) => {
    emit("subcategorySelected", subCategory);
  };

  const GetCategories = async () => {
    const response = await fetch(baseUrl + "/api/categories");
    const data = await response.json();
    categories.value = data;
  };

  const GetSubCategories = async () => {
    const response = await fetch(baseUrl + "/api/subCategories");
    const data = await response.json();
    console.log(data);
    subCategories.value = data;
  };

  onBeforeMount(async () => {
    await GetCategories();
    await GetSubCategories();
  });

  const toggleSubCategories = async (category) => {
    console.log(category)
    if (category.id == 1) {
      router.push("/specials")
    }
    if (category.showSubCategories) {
      category.showSubCategories = false;
      subsToShow.value = [];
      return;
    }

    categories.value.forEach((cat) => {
      cat.showSubCategories = false;
    });

    subsToShow.value = subCategories.value.filter(
      (subCategory) => subCategory.categoryId === category.id
    );

    category.showSubCategories = true;
  };
</script>

<template>
  <div class="side-nav-container">
    <div class="big-btn-container" v-for="(category, index) in categories" :key="index">
      <button :class="['bigmenuitem', { active: category.showSubCategories }]"
              @click="toggleSubCategories(category)">
        {{ category.name }}
      </button>
      <div v-if="category.showSubCategories" class="subcategories">
        <div class="sub-btn-container">
          <button v-for="(subCategory, subIndex) in subsToShow"
                  :key="subIndex"
                  href="#"
                  class="subcat-btn"
                  @click="handleSubCategoryClick(subCategory)">
            {{ subCategory.name }}
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<style>
  .subcategories {
    background-color: white;
  }

  .subcat-btn {
    color: black;
    background-color: lightgray;
    border: none;
    padding: 10px;
    cursor: pointer;
    width: 100%;
  }

    .subcat-btn:hover {
      background-color: green;
      color: white;
    }
</style>
