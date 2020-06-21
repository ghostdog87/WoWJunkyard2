<template>
  <main role="main" class="pb-3">
    <table class="table table-striped table-dark table-hover">
      <thead>
        <tr>
          <th>#</th>
          <th>
            <span style="visibility: hidden">icon</span>
          </th>
          <th>Class</th>
          <th>Character Name</th>
          <th>Realm</th>
          <th>model.Race</th>
          <th>Level</th>
          <th>AchievementPoints</th>
          <th>Faction</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>row number</td>
          <td style="padding:6px 0 0 0">character.Thumbnail</td>
          <td>
            <div class="class">classes</div>
          </td>
          <td>
            <a href="#">item.Name</a>
          </td>
          <td>Realm</td>
          <td>race</td>
          <td>Level</td>
          <td>AchievementPoints</td>
          <td>faction</td>
        </tr>
      </tbody>
    </table>

    <div class="text-warning text-center" style="font-size: 2em">No results</div>
  </main>
</template>

<script>
export default {
  name: "charactersList",
  components: {},
  data: () => ({}),
  computed: {},
  filters: {},
  method: {},
  created() {}
};
</script>

<style scoped>
</style>