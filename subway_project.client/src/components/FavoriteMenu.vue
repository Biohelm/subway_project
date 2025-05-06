<script setup>
    import { ref, onMounted} from 'vue';
    import { useSubStore } from '@/stores/subStore';
    import { useOrderStore } from '@/stores/useOrderStore';

    const subStore = useSubStore();
    const orderStore = useOrderStore();
    const favorites = ref([]);
    const error = ref("");
    const loading = ref(true);

    async function getSpecials() {
    try {
      const response = await fetch('/api/Favorites')
      if (!response.ok) {
        throw new Error('Failed to fetch favorites')
      }
      favorites.value = await response.json()
    }
    catch (err) {
      error.value = err.message
    }
    finally {
      loading.value = false
    }
  }

  onMounted(() => {
    getSpecials();
  });

  function createOrder(fav) {
        fav.products.forEach(p => {
            if (p.categoryId == 2) {
                subStore.addProduct(p)
            }
            else {
                orderStore.addProduct(p)
            }
        });
        orderStore.addSubToOrder(subStore.sub);
        subStore.resetSub(false);
    }

</script>

<template>
<h1>Favorites</h1>
<ul class="fav-ul">
    <li v-for="s in favorites" class="fav-li">
        <button @click="createOrder(s)">
            <img :src="s.imgUrl" alt="Sandwich">
            <p>{{ s.name }}</p>
        <p>{{ s.price }}kr</p>
        <p>{{ s.description }}</p>
        </button>
    </li>
</ul>
</template>

<style>
img {
    width: 15vw;
}

.fav-ul {
    width: 1rem;
    padding: 1rem;
}
.fav-li {
    width: 1rem;
    cursor: pointer;
}
.fav-li:hover {
    cursor: pointer;
}
</style>