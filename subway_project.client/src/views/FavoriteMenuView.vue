<script setup>
import router from "@/router";
  import SideNav from "../components/SideNav.vue";
  import TopNav from "../components/TopNav.vue";
  import CartNav from '@/components/CartNav.vue';
  import FavoriteMenu from "@/components/FavoriteMenu.vue";

  function goToOrder() {
    router.push("/order")
  }

</script>

<template>
  <div class="page-container">
    <nav>
      <TopNav />
    </nav>
    <aside>
      <SideNav @subcategory-selected="handleSubCategorySelected" @click="goToOrder"/>
    </aside>
    <section>
      <FavoriteMenu />
    </section>
    <div class="cart">
      <CartNav :cart-limits="cartLimits" />
    </div>
  </div>
</template>