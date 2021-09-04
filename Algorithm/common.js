//将一个数字分成N个数字相加
function splitNumber(total, count) {
	const result = []
	function _splitNumber(start, cache) {
		if (cache.length > count) {
			return
		}
		const _result = cache.reduce((acc, cur) => {
			return acc + cur
		}, 0)
		if (cache.length == count) {
			if (_result == total) {
				result.push(cache)
			}
			return
		}
		for (var i = start; i <= total - _result; i++) {
			const _cache = [...cache]
			_cache.push(i)
			_splitNumber(i + 1, _cache)
		}
	}
	_splitNumber(1, [])
	return result
}
splitNumber(1000, 5);

